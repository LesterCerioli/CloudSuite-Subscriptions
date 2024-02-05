using CloudSuite.Modules.Application.Handlers.Contacts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Subscriptions.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
        private readonly ILogger<ContactApiController> _logger;
        private readonly IMediator _mediator;

        public ContactApiController(ILogger<ContactApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand createCommand)
        {
            var result = await _mediator.Send(createCommand);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
