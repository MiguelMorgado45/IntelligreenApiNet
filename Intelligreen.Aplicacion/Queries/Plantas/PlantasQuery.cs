using Intelligreen.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion.Queries.Plantas
{
    public class PlantasQuery : IRequest<IEnumerable<Planta>>
    {
    }

    public class PlantasQueryHandler : IRequestHandler<PlantasQuery, IEnumerable<Planta>>
    {
        private readonly ApplicationDbContext _context;

        public PlantasQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Planta>> Handle(PlantasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Plantas.ToListAsync(cancellationToken);
        }
    }
}
