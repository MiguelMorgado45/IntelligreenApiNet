using System.Text.Json.Serialization;

namespace Intelligreen.Dominio
{
    public class Dispositivo
    {
        public Guid DispositivoId { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid CircuitoId { get; set; }
        [JsonIgnore]
        public List<PlantaUsuario> PlantaUsuarios { get; set; } = null!;
    }
}
