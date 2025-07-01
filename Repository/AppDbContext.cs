using gr2_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Equipamento> Equipamentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").IsRequired();
            });

            entity.OwnsOne(u => u.Senha, senha =>
            {
                senha.Property(s => s.Value).HasColumnName("Senha").IsRequired();
            });
        });
    }
    }
}