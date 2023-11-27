using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Customers.Responses;
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
    public class CheckCustomerExistsByCreatedOnHandler : IRequestHandler<CheckCustomerExistsByCreatedOnRequest, CheckCustomerExistsByCreatedOnResponse>
    {
        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByCreatedOnHandler> _logger;

        public CheckCustomerExistsByCreatedOnHandler(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByCreatedOnHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByCreatedOnResponse> Handle(CheckCustomerExistsByCreatedOnRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByCreatedOnRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByCreatedOnRequestValidation().Validate(request);

            if(validationResult.IsValid )
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByCreatedOn(request.CreatedOn);

                    if (customer != null)
                    {
                        return await Task.FromResult(new CheckCustomerExistsByCreatedOnResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByCreatedOnResponse(request.Id, "Não foi possível processar a sua solicitação."));
                }
            }
            return await Task.FromResult(new CheckCustomerExistsByCreatedOnResponse(request.Id, false, validationResult));
        }
    }
}
