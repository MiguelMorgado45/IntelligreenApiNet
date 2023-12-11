using Intelligreen.Dominio;
using MediatR;

namespace Intelligreen.Aplicacion.Commands.Plantas
{
    public class CrearPlantaUsuarioCommand : IRequest<Unit>
    {
        public Guid PlantaId { get; set; }
        public Guid DispositivoId { get; set; }
        public string Apodo { get; set; } = null!;
    }

    public class CrearPlantaUsuarioCommandHandler : IRequestHandler<CrearPlantaUsuarioCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public CrearPlantaUsuarioCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CrearPlantaUsuarioCommand request, CancellationToken cancellationToken)
        {
            var plantaUsuario = new PlantaUsuario
            {
                PlantaUsuarioId = Guid.NewGuid(),
                PlantaId = request.PlantaId,
                DispositivoId = request.DispositivoId,
                Apodo = request.Apodo
            };

            _context.PlantasUsuarios.Add(plantaUsuario);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
