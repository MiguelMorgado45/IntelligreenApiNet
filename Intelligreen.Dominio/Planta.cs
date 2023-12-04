using System.ComponentModel.DataAnnotations;

namespace Intelligreen.Dominio
{
    public enum Dificultad
    {
        [Display(Name = "Fácil")]
        Facil = 1,
        [Display(Name = "Media")]
        Media = 2,
        [Display(Name = "Difícil")]
        Dificil = 3
    }

    public class Planta
    {
        public Guid PlantaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string NombreCientifico { get; set; } = null!;
        public Dificultad Dificultad { get; set; }
        public string ImgUrl { get; set; } = null!;
    }
}
