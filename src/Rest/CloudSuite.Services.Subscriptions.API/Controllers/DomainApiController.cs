using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Subscriptions.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DomainApiController : ControllerBase
	{
		private readonly ILogger<DomainApiController> _logger;
		private readonly IMediator _mediator;

		
		public DomainApiController(ILogger<DomainApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;

		}


		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromRoute] CreateDomainCommand commandCreate)
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


		[HttpGet]
		[Route("exists/dns/{dns}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DnsExists([FromRoute] string dns)
		{
			var result = await _mediator.Send(new CheckDomainExistsByDnsRequest(dns));
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
		[Route("exists/creationdate/{creationdate}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreationDateExists([FromRoute] DateTimeOffset creationDate)
		{
			var result = await _mediator.Send(new CheckDomainExistsByCreationDateRequest(creationDate));
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
