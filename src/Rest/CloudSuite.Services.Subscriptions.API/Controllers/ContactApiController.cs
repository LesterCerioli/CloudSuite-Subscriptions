using CloudSuite.Modules.Application.Handlers.Contacts;
using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
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

        [HttpGet]
        [Route("exists/email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EmailExists([FromRoute] string email)
        {
            var result = await _mediator.Send(new CheckContactExistsByEmailRequest(email));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        [Route("exists/name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NameExists([FromRoute] string name)
        {
            var result = await _mediator.Send(new CheckContactExistsByNameRequest(name));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        [Route("exists/telephone/{telephone}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> TelephoneExists([FromRoute] string telephone)
        {
            var result = await _mediator.Send(new CheckContactExistsByNameRequest(telephone));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
