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
        public string Descripcion { get; set; } = null!;
        public Dificultad Dificultad { get; set; }
        public string ImgUrl { get; set; } = null!;
        public double MinTempAmb { get; set; }
        public double MaxTempAmb { get; set; }
        public double MinHumedadAmb { get; set; }
        public double MaxHumedadAmb { get; set; }
        public double MinHumedadSuelo { get; set; }
        public double MaxHumedadSuelo { get; set; }
        public IList<string> Cuidados { get; set; } = new List<string>();
    }
}
