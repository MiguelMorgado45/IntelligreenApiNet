using Intelligreen.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion.Commands.Dispositivos
{
    public class UpsertDispositivoCommand : IRequest<Unit>
    {
        public string? DispositivoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string CircuitoId { get; set; } = null!;
    }

    public class UpsertDispositivoCommandHandler : IRequestHandler<UpsertDispositivoCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpsertDispositivoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpsertDispositivoCommand request, CancellationToken cancellationToken)
        {
            var dispositivoExistente = await _context.Dispositivos.FirstOrDefaultAsync(x => x.CircuitoId.Equals(Guid.Parse(request.CircuitoId)));

            if (dispositivoExistente is null)
            {
                var dispositivo = new Dispositivo
                {
                    DispositivoId = Guid.NewGuid(),
                    Nombre = request.Nombre,
                    CircuitoId = Guid.Parse(request.CircuitoId)
                };

                _context.Dispositivos.Add(dispositivo);
            }
            else
            {
                dispositivoExistente.Nombre = request.Nombre;
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
