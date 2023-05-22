using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locacao>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Cliente) // Relação muitos-para-um com Cliente
                .WithMany()
                .HasForeignKey(l => l.ClienteId)
                .IsRequired();

            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Filme) // Relação muitos-para-um com Filme
                .WithMany()
                .HasForeignKey(l => l.FilmeId)
                .IsRequired();
        }

    }
}
