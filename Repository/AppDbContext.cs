using gr2_api.Models;
using gr2_api.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            var emailConverter = new ValueConverter<Email, string>(
                e => e.Value,
                v => Email.Create(v).Value
            );

            var senhaConverter = new ValueConverter<Senha, string>(
                s => s.Value,
                v => new Senha(v)
            );

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.Email)
                    .HasConversion(emailConverter)
                    .HasColumnName("Email")
                    .IsRequired();

                entity.Property(u => u.Senha)
                    .HasConversion(senhaConverter)
                    .HasColumnName("Senha")
                    .IsRequired();
            });
        }
    }
}