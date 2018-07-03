using System.Data.Entity.ModelConfiguration;
using TrabalhoFinal.Dominio.Entidades;

namespace TrabalhoFinal.Infra.Dados.Configuracoes
{
    public class ReservaConfiguracao : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfiguracao()
        {
            ToTable("TBPedido");

            HasKey(o => o.Id);

            Property(o => o.DataReserva)
                .HasColumnType("datetime")
                .IsRequired();

            Property(o => o.ValorTotal)
                .IsRequired();

            HasRequired(a => a.Cliente)
                  .WithMany()
                  .WillCascadeOnDelete(true);

            HasMany(a => a.Quartos)
                     .WithMany(p => p.Reservas)
                     .Map(cs =>
                     {
                         cs.MapLeftKey("QuartoId");
                         cs.MapRightKey("ReservaId");
                         cs.ToTable("TBReservaQuarto");
                     });
        }
    }
}
