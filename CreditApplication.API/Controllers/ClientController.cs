using CreditApplication.Application.UseCases.Commands.CreateClientCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            if (command == null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(new { message = "Client created successfully" });
            }

            return BadRequest(response);
        }
    }
}
