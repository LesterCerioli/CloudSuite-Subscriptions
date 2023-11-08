using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Validations.Customers;
using CloudSuite.Modules.Domain.Contracts.CustomerRepository;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByCnpjHandlers : IRequestHandler<CheckCustomerExistsByCnpjRequest, CheckCustomerExistsByCnpjResponse>
    {
        private ICustomerRepository _customerRepository;
        private readonly ILogger<CheckCustomerExistsByCnpjHandlers> _logger;

        public CheckCustomerExistsByCnpjHandlers(ICustomerRepository customerRepository, ILogger<CheckCustomerExistsByCnpjHandlers> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByCnpjResponse> Handle(CheckCustomerExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckCustomerExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var customer = await _customerRepository.GetByCnpj(request.Cnpj);

                    if (customer != null)
                        return await CheckCustomerExistsByCnpjResponse(request.Id, true, validationResult);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await CheckCustomerExistsByCnpjResponse(request.Id, "Não foi possível processar a solicitação!");
                }
            }
            return await CheckCustomerExistsByCnpjResponse(request.Id, false, validationResult);
        }
    }
}
