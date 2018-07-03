using System;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Dominio.Enums;

namespace TrabalhoFinal.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Cliente CriarCliente()
        {
            return new Cliente
            {
                Id = 1,
                PrimeiroNome = "William",
                Sobrenome = "Souza",
                Telefone = "(49) 99999999",
                DataNascimento = new DateTime(1996, 10, 29),
                Endereco = new Endereco
                {
                    Numero = "11",
                    Logradouro = "Rua tal",
                    Bairro = "Copacabana",
                    Localidade = "Lages",
                    Uf = "SC",
                    Cep = "88 000 000",
                    Complemento = ""
                },
            };
        }

        public static Reserva CriarReserva()
        {
            return new Reserva
            {
                Id = 1,
                Cliente = CriarCliente()
            };
        }

        public static Quarto CriarQuarto()
        {
            return new Quarto
            {
                Id = 1,
                Nome = "Solteiro 1 Cama",
                Preco = 70,
                TipoQuarto = TipoQuarto.Solteiro
            };
        }
    }
}
