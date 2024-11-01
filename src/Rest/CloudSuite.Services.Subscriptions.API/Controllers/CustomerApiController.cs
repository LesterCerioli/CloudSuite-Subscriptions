﻿using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
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


		[HttpGet]
		[Route("exists/businessowner/{businessowner}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> BusinessOwnerExists([FromRoute] string businessOwner)
		{
			var result = await _mediator.Send(new CheckCustomerExistsByBusinessOwnerRequest(businessOwner));
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
		[Route("exists/email/{email}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> EmailExists([FromRoute] string email)
		{
			var result = await _mediator.Send(new CheckCustomerExistsByEmailRequest(email));
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
		[Route("exists/cnpj/{cnpj}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CnpjExists([FromRoute] string cnpj)
		{
			var result = await _mediator.Send(new CheckCustomerExistsByCnpjRequest(cnpj));
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
