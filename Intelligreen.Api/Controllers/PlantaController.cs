using Intelligreen.Aplicacion.Commands.Plantas;
using Intelligreen.Aplicacion.Queries.Plantas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligreen.Api.Controllers
{
    public class PlantaController : BaseController
    {
        private readonly IMediator _mediator;

        public PlantaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPlantas()
        {
            var plantas = await _mediator.Send(new PlantasQuery());

            return Ok(plantas);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlanta(CrearPlantaCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
