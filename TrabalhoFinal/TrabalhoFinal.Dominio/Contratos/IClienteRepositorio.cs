using TrabalhoFinal.Dominio.Entidades;

namespace TrabalhoFinal.Dominio.Contratos
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Cliente BuscarPorNome(string nome);

        Cliente BuscarPorTelefone(string telefone);
    }
}
