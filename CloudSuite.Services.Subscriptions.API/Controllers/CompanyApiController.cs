
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Company.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Subscriptions.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyApiController : ControllerBase
	{
		private readonly ILogger<CompanyApiController> _logger;
		private readonly IMediator _mediator;

		public CompanyApiController(ILogger<CompanyApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}


		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreateCompanyCommand createCommand)
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
		[Route("exists/cnpj/{cnpj}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CnpjExists([FromRoute] string cnpj)
		{
			var result = await _mediator.Send(new CheckCompanyExistsByCnpjRequest(cnpj));
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
		[Route("exists/fantasyname/{fantasyname}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> FantasyNameExists([FromRoute] string fantasyName)
		{
			var result = await _mediator.Send(new CheckCompanyExistsByFantasyNameRequest(fantasyName));
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
		[Route("exists/socialname/{socialname}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SocialNameExists([FromRoute] string socialName)
		{
			var result = await _mediator.Send(new CheckCompanyExistsBySocialNameRequest(socialName));
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
