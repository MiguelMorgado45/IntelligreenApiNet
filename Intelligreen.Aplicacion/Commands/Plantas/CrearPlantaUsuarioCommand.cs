using Intelligreen.Dominio;
using MediatR;

namespace Intelligreen.Aplicacion.Commands.Plantas
{
    public class CrearPlantaUsuarioCommand : IRequest<Unit>
    {
        public string? PlantaUsuarioId { get; set; }
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
            if (string.IsNullOrEmpty(request.PlantaUsuarioId))
            {
                var plantaUsuario = new PlantaUsuario
                {
                    PlantaUsuarioId = Guid.NewGuid(),
                    PlantaId = request.PlantaId,
                    DispositivoId = request.DispositivoId,
                    Apodo = request.Apodo
                };

                _context.PlantasUsuarios.Add(plantaUsuario);
            }
            else
            {
                var plantaUsuario = await _context.PlantasUsuarios.FindAsync(Guid.Parse(request.PlantaUsuarioId));
                plantaUsuario.Apodo = request.Apodo;
                plantaUsuario.DispositivoId = request.DispositivoId;
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
