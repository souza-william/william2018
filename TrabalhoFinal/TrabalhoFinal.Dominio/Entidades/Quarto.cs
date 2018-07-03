using System;
using System.Collections.Generic;
using TrabalhoFinal.Dominio.Enums;
using TrabalhoFinal.Dominio.Excecoes;

namespace TrabalhoFinal.Dominio.Entidades
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public TipoQuarto TipoQuarto { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        public Quarto()
        {
        }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new DominioException("Nome inválido!");
            if (Preco < 1)
                throw new DominioException("Preço inválido!");
            if (TipoQuarto < 0)
                throw new DominioException("Tipo inválido!");
        }

    }
}
