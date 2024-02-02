using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Payments;
using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Subscriptions.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentApiController : ControllerBase
	{
		private readonly ILogger<PaymentApiController> _logger;
		private readonly IMediator _mediator;

		public PaymentApiController(ILogger<PaymentApiController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}


		[AllowAnonymous]
		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] CreatePaymentCommand createCommand)
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
			var result = await _mediator.Send(new CheckPaymentExistsByCnpjRequest(cnpj));
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
		[Route("exists/number/{number}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> NumberExists([FromRoute] string number)
		{
			var result = await _mediator.Send(new CheckPaymentExistsByNumberRequest(number));
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
		[Route("exists/payer/{payer}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> PayerExists([FromRoute] string payer)
		{
			var result = await _mediator.Send(new CheckPaymentExistsByPayerRequest(payer));
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
