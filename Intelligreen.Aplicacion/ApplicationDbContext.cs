using Intelligreen.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantaUsuario>()
                .HasOne(x => x.Planta)
                .WithMany(y => y.PlantaUsuarios)
                .HasForeignKey(x => x.PlantaId);

            modelBuilder.Entity<PlantaUsuario>()
                .HasOne(x => x.Dispositivo)
                .WithMany(y => y.PlantaUsuarios)
                .HasForeignKey(x => x.DispositivoId);

            modelBuilder.Entity<Planta>()
                .HasMany(x => x.PlantaUsuarios)
                .WithOne(y => y.Planta)
                .HasForeignKey(x => x.PlantaId);

            modelBuilder.Entity<Dispositivo>()
                .HasMany(x => x.PlantaUsuarios)
                .WithOne(y => y.Dispositivo)
                .HasForeignKey(x => x.DispositivoId);
        }

        public DbSet<Planta> Plantas { get; set; } = null!;
        public DbSet<Dispositivo> Dispositivos { get; set; } = null!;
        public DbSet<PlantaUsuario> PlantasUsuarios { get; set; } = null!;
    }
}
