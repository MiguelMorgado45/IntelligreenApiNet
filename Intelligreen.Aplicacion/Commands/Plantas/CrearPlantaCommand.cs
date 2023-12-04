using Intelligreen.Dominio;
using MediatR;

namespace Intelligreen.Aplicacion.Commands.Plantas
{
    public class CrearPlantaCommand : IRequest<Unit>
    {
        public string Nombre { get; set; } = null!;
        public string NombreCientifico { get; set; } = null!;
        public Dificultad Dificultad { get; set; }
        public string ImgUrl { get; set; } = null!;
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
                Dificultad = request.Dificultad,
                ImgUrl = request.ImgUrl,
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
