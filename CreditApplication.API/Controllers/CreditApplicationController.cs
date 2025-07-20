using CreditApplication.Application.UseCases.Commands.CreateApplicationCommand;
using CreditApplication.Application.UseCases.Queries.GetApplicationByClientQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetApplies")]
        public async Task<IActionResult> GetApplies([FromQuery] int clientId)
        {
            if (clientId == 0) return BadRequest();

            var result = await _mediator.Send(new GetApplicationByClientQuery { IdClient = clientId });

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateApplies(CreateApplicationCommand command)
        {
            if (command == null) return BadRequest();

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(new {message = "Application created successfully" });
            }

            return BadRequest(result);
        }
    }
}
