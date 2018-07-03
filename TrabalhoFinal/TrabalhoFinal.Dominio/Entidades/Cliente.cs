using System;
using TrabalhoFinal.Dominio.Excecoes;

namespace TrabalhoFinal.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }

        public string NomeCompleto
        {
            get
            {
                return String.Format("{0} {1}",
                    PrimeiroNome, Sobrenome);
            }
        }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(PrimeiroNome))
                throw new DominioException("Primeiro nome inválido!");
            if (String.IsNullOrWhiteSpace(Sobrenome))
                throw new DominioException("Sobrenome inválido!");
            if (String.IsNullOrWhiteSpace(Telefone))
                throw new DominioException("Telefone inválido!");
            if (DataNascimento == new DateTime(0001, 01, 01))
                throw new DominioException("Data nascimento inválida!");
            if (Endereco == null)
                throw new DominioException("Endereço inválido!");
        }
    }
}
