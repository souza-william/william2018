using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TrabalhoFinal.Dominio.Contratos;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Infra.Dados.Contexto;

namespace TrabalhoFinal.Infra.Dados.Repositorios
{
    public class QuartoRepositorio : IQuartoRepositorio
    {
        public HotelContexto _contexto;

        public QuartoRepositorio()
        {
            _contexto = new HotelContexto();
        }

        public void Adicionar(Quarto entidade)
        {

            _contexto.Quartos.Add(entidade);

            _contexto.SaveChanges();
        }

        public Quarto BuscarPor(int id)
        {
            return _contexto.Quartos.Find(id);
        }

        public Quarto BuscarPorNome(string nome)
        {
            return _contexto.Quartos
                .Where(p => p.Nome == nome)
                .FirstOrDefault();
        }

        public List<Quarto> BuscarTudo()
        {
            return _contexto.Quartos.ToList();
        }

        public void Deletar(Quarto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Quartos.Attach(entidade);
            }

            _contexto.Quartos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Quarto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Quartos.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
