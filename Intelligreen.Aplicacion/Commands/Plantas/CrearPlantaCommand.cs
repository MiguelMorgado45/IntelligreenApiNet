using Intelligreen.Dominio;
using MediatR;

namespace Intelligreen.Aplicacion.Commands.Plantas
{
    public class CrearPlantaCommand : IRequest<Unit>
    {
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

    public class CrearPlantaCommandHandler : IRequestHandler<CrearPlantaCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public CrearPlantaCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CrearPlantaCommand request, CancellationToken cancellationToken)
        {
            _context.Plantas.Add(new Planta
            {
                Nombre = request.Nombre,
                NombreCientifico = request.NombreCientifico,
                Descripcion = request.Descripcion,
                Dificultad = request.Dificultad,
                ImgUrl = request.ImgUrl,
                MinTempAmb = request.MinTempAmb,
                MaxTempAmb = request.MaxTempAmb,
                MinHumedadAmb = request.MinHumedadAmb,
                MaxHumedadAmb = request.MaxHumedadAmb,
                MinHumedadSuelo = request.MinHumedadSuelo,
                MaxHumedadSuelo = request.MaxHumedadSuelo,
                Cuidados = request.Cuidados
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
