using Intelligreen.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Intelligreen.Aplicacion.Queries.Plantas
{
    public class PlantasUsuariosQuery : IRequest<List<PlantaUsuario>>
    {
    }

    public class PlantasUsuariosQueryHandler : IRequestHandler<PlantasUsuariosQuery, List<PlantaUsuario>>
    {
        private readonly ApplicationDbContext _context;

        public PlantasUsuariosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlantaUsuario>> Handle(PlantasUsuariosQuery request, CancellationToken cancellationToken)
        {
            var plantas = await _context.PlantasUsuarios
                .Include(x => x.Planta)
                .Include(y => y.Dispositivo)
                .ToListAsync(cancellationToken);

            return plantas;
        }
    }
}
