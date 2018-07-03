using System;
using System.Collections.Generic;
using TrabalhoFinal.Dominio.Excecoes;

namespace TrabalhoFinal.Dominio.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public double ValorTotal { get; private set; }

        public virtual List<Quarto> Quartos { get; set; }

        public DateTime DataReserva { get; set; }

        public Reserva()
        {
            DataReserva = DateTime.Now;
        }

        public void Adiciona(Quarto quarto)
        {
            Quartos.Add(quarto);
        }

        public void Remover(Quarto quarto)
        {
            Quartos.Remove(quarto);
        }

        public void Validar()
        {
            if (Cliente == null)
                throw new DominioException("Cliente inválido!");
            if (Quartos == null)
                throw new DominioException("Deve ter pelo menos uma reserva!");
            if (ValorTotal < 0)
                throw new DominioException("Tipo inválido!");
        }

        public void CalculaTotal()
        {
            foreach (var quartos in Quartos)
            {
                ValorTotal += quartos.Preco;
            }
        }

    }
}
