using Intelligreen.Aplicacion.Commands.Plantas;
using Intelligreen.Aplicacion.Queries.Plantas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligreen.Api.Controllers
{
    public class PlantaUsuarioController : BaseController
    {
        private readonly IMediator _mediator;

        public PlantaUsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPlantasUsuarios()
        {
            var plantasUsuarios = await _mediator.Send(new PlantasUsuariosQuery());

            return Ok(plantasUsuarios);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlantaUsuario(CrearPlantaUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
