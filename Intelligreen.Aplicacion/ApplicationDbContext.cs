using Intelligreen.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Planta> Plantas { get; set; } = null!;
    }
}
