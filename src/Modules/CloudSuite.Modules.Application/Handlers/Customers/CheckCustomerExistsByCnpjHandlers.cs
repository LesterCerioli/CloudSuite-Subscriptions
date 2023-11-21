using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByCnpjHandlers : IRequestHandler<CheckCustomerExistsByCnpjRequest, CheckCustomerExistsByCnpjResponse>
    {
        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByCnpjHandlers> _logger;

        public CheckCustomerExistsByCnpjHandlers(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByCnpjHandlers> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByCnpjResponse> Handle (CheckCustomerExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCustomerExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByCnpj(new Cnpj(request.Cnpj));
                    if (customer != null)
                    {
                        return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, "Não foi poss[ivel processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckCustomerExistsByCnpjResponse(request.Id, false, validationResult));
        }
    }
}