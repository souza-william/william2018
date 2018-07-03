using TrabalhoFinal.Dominio.Entidades;

namespace TrabalhoFinal.Dominio.Contratos
{
    public interface IQuartoRepositorio : IRepositorio<Quarto>
    {
        Quarto BuscarPorNome(string nome);
    }
}
