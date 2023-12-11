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
        public DbSet<Dispositivo> Dispositivos { get; set; } = null!;
        public DbSet<PlantaUsuario> PlantasUsuarios { get; set; } = null!;
    }
}
