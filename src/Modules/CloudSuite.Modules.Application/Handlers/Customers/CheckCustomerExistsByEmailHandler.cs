using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Application.Validation.Customer;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByEmailHandler : IRequestHandler<CheckCustomerExistsByEmailRequest, CheckCustomerExistsByEmailResponse>
    {

        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByEmailHandler> _logger;

        public CheckCustomerExistsByEmailHandler(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByEmailHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByEmailResponse> Handle(CheckCustomerExistsByEmailRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByEmailRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByEmailRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByEmail(new Email(request.Email));
                    if (customer != null)
                    {
                        return await Task.FromResult(new CheckCustomerExistsByEmailResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByEmailResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckCustomerExistsByEmailResponse(request.Id, false, validationResult));
        }
    }
}
