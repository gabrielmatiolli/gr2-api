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
    }
}