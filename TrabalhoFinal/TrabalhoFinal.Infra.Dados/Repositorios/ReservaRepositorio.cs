using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TrabalhoFinal.Dominio.Contratos;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Infra.Dados.Contexto;

namespace TrabalhoFinal.Infra.Dados.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        public HotelContexto _contexto;

        public ReservaRepositorio()
        {
            _contexto = new HotelContexto();
        }

        public void Adicionar(Reserva entidade)
        {
            _contexto.Reservas.Add(entidade);

            _contexto.SaveChanges();
        }

        public Reserva BuscarPor(int id)
        {
            return _contexto.Reservas.Find(id);
        }

        public List<Reserva> BuscarTudo()
        {
            return _contexto.Reservas.ToList();
        }

        public void Deletar(Reserva entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Reservas.Attach(entidade);
            }

            _contexto.Reservas.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Reserva entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Reservas.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
