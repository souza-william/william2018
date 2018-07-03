using System;
using System.Collections.Generic;
using System.Data.Entity;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Dominio.Enums;
using TrabalhoFinal.Infra.Dados.Contexto;

namespace TrabalhoFinal.Testes.Base
{
    public class InicializadorBanco<T> : DropCreateDatabaseAlways<HotelContexto>
    {
        protected override void Seed(HotelContexto context)
        {
            //Cria quarto
            Quarto quarto1 = new Quarto();
            quarto1.Nome = "Solteiro";
            quarto1.Preco = 70;
            quarto1.TipoQuarto = TipoQuarto.Solteiro;

            Quarto quarto2 = new Quarto();
            quarto2.Nome = "Casal";
            quarto2.Preco = 100;
            quarto2.TipoQuarto = TipoQuarto.Casal;

            var listaQuarto = new List<Quarto>() { quarto1, quarto2 };

            //Criar cliente
            Cliente cliente = new Cliente();
            cliente.PrimeiroNome = "William";
            cliente.Sobrenome = "Souza";
            cliente.Telefone = "(49) 9 99999999";
            cliente.DataNascimento = DateTime.Now.AddYears(-21);

            cliente.Endereco = new Endereco
            {
                Cep = "88500000",
                Logradouro = "Rua tal",
                Complemento = "111",
                Bairro = "Copacabana",
                Localidade = "Lages",
                Uf = "SC",
                Numero = "123"
            };

            //Cria reserva
            Reserva reserva = new Reserva();
            reserva.Cliente = cliente;
            reserva.DataReserva = DateTime.Now;

            //Adiciona os quartos
            reserva.Quartos = listaQuarto;

            //Fecha reserva
            reserva.CalculaTotal();

            //Adicionar no contexto
            context.Reservas.Add(reserva);

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
