using System;

namespace TrabalhoFinal.Dominio.Excecoes
{
    public class DominioException : Exception
    {
        public DominioException(string message)
            : base(message)
        {
        }
    }
}
