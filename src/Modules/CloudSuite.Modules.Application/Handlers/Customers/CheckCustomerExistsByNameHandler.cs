using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Application.Validation.Customer;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByNameHandler : IRequestHandler<CheckCustomerExistsByNameRequest, CheckCustomerExistsByNameResponse>
    {
        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByNameHandler> _logger;

        public CheckCustomerExistsByNameHandler(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByNameHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByNameResponse> Handle(CheckCustomerExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByName(request.Name);
                    if(customer != null)
                    {
                        return await Task.FromResult(new CheckCustomerExistsByNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByNameResponse(request.Id, "Não fio possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckCustomerExistsByNameResponse(request.Id, false, validationResult));
        }
    }
}
