namespace Intelligreen.Dominio
{
    public class PlantaUsuario
    {
        public Guid PlantaUsuarioId { get; set; }
        public string Apodo { get; set; }
        public Guid PlantaId { get; set; }
        public Guid DispositivoId { get; set; }
        public Planta Planta { get; set; } = null!;
        public Dispositivo Dispositivo { get; set; } = null!;
    }
}
