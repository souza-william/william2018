using System.Collections.Generic;

namespace TrabalhoFinal.Dominio.Contratos
{
    public interface IRepositorio<T>
    {
        void Adicionar(T entidade);

        void Editar(T entidade);

        T BuscarPor(int id);

        List<T> BuscarTudo();

        void Deletar(T entidade);
    }
}