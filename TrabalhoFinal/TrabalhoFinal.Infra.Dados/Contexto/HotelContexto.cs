using System.Data.Entity;
using TrabalhoFinal.Dominio.Entidades;
using TrabalhoFinal.Infra.Dados.Configuracoes;

namespace TrabalhoFinal.Infra.Dados.Contexto
{
    public class HotelContexto : DbContext
    {
        public DbSet<Quarto> Quartos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public HotelContexto() : base("HotelDB")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quarto>()
                .ToTable("TBQuarto");

            modelBuilder.Entity<Quarto>()
                .Ignore(p => p.Reservas);

            modelBuilder.Entity<Quarto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Quarto>()
                .Property(p => p.Nome)
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();

            modelBuilder.Entity<Quarto>()
                .Property(p => p.Preco)
                  .IsRequired();

            modelBuilder.Entity<Quarto>()
                .Property(p => p.TipoQuarto)
                  .HasColumnType("tinyint")
                  .IsRequired();

            modelBuilder.Entity<Cliente>()
               .ToTable("TBCliente");

            modelBuilder.Configurations.Add(new ReservaConfiguracao());
        }
    }
}
