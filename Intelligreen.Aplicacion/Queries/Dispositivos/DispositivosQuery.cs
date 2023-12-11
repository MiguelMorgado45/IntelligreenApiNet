using Intelligreen.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion.Queries.Dispositivos
{
    public class DispositivosQuery : IRequest<IEnumerable<Dispositivo>>
    {
    }

    public class DispositivosQueryHandler : IRequestHandler<DispositivosQuery, IEnumerable<Dispositivo>>
    {
        private readonly ApplicationDbContext _context;

        public DispositivosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dispositivo>> Handle(DispositivosQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Dispositivos.ToListAsync(cancellationToken);
        }
    }
}
