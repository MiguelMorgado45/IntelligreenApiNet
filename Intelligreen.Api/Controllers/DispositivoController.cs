using Intelligreen.Aplicacion.Commands.Dispositivos;
using Intelligreen.Aplicacion.Queries.Dispositivos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intelligreen.Api.Controllers
{
    public class DispositivoController : BaseController
    {
        private readonly IMediator _mediator;

        public DispositivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDispositivos()
        {
            var dispositivos = await _mediator.Send(new DispositivosQuery());

            return Ok(dispositivos);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertDispositivo(UpsertDispositivoCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
