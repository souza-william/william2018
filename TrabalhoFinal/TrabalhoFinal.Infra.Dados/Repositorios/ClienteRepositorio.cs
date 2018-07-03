using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TrabalhoFinal.Dominio.Contratos;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Infra.Dados.Contexto;

namespace TrabalhoFinal.Infra.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public HotelContexto _contexto;

        public ClienteRepositorio()
        {
            _contexto = new HotelContexto();
        }

        public void Adicionar(Cliente entidade)
        {
            _contexto.Clientes.Add(entidade);

            _contexto.SaveChanges();
        }

        public Cliente BuscarPor(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public Cliente BuscarPorNome(string nome)
        {
            return _contexto.Clientes
                .Where(p => p.PrimeiroNome == nome)
                .FirstOrDefault();
        }

        public Cliente BuscarPorTelefone(string telefone)
        {
            return _contexto.Clientes
                .Where(p => p.Telefone == telefone)
                .FirstOrDefault();
        }

        public List<Cliente> BuscarTudo()
        {
            return _contexto.Clientes.ToList();
        }

        public void Deletar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.Clientes.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}
