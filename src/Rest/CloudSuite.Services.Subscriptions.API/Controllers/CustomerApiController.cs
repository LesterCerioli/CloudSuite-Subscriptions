using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Subscriptions.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerApiController : ControllerBase
	{
		private readonly ILogger<CustomerApiController> _logger;
		private readonly IMediator _mediator;

		public CustomerApiController(ILogger<CustomerApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}


		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromRoute] CreateCustomerCommand commandCreate)
		{
			var result = await _mediator.Send(commandCreate);
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
