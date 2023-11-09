using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
using CloudSuite.Modules.Domain.Contracts;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByCnpjHandlers : IRequestHandler<CheckCustomerExistsByCnpjRequest, CheckCustomerExistsByCnpjResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CheckCustomerExistsByCnpjHandlers> _logger;

        public CheckCustomerExistsByCnpjHandlers(ICustomerRepository customerRepository, ILogger<CheckCustomerExistsByCnpjHandlers> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByCnpjResponse> Handle(CheckCustomerExistsByCnpjRequest request, CancellationToken cancellationToken)
{
    _logger.LogInformation($"CheckCustomerExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");

    var validationResult = new CreateCustomerCommandValidate().Validate(command);

    if (validationResult.IsValid)
    {
        try
        {
            var customer = await _customerRepository.GetByCnpj(request.Cnpj);

            if (customer != null)
                return new CheckCustomerExistsByCnpjResponse(request.Id, true, validationResult);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.Message);
            return new CheckCustomerExistsByCnpjResponse(request.Id, "Não foi possível processar a solicitação!");
        }
    }
    return new CheckCustomerExistsByCnpjResponse(request.Id, false, validationResult);
}

    }
}
