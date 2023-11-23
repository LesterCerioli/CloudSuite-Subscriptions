using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Application.Validation.Customer;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CreateCustomerHandler
    {
        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CreateCustomerHandler> _logger;

        public CreateCustomerHandler(ICustomerRepository repositorioCustomer, ILogger<CreateCustomerHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellation)
        {
            _logger.LogInformation($"CreateCustomerCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCustomerCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByCnpj(new Cnpj(command.Cnpj));
                    if (customer != null)
                    {
                        return await Task.FromResult(new CreateCustomerResponse(command.Id, "cliente já foi cadastrado!"));
                    }

                    await _repositorioCustomer.Add(command.GetEntity());
                    return await Task.FromResult(new CreateCustomerResponse(command.Id, validationResult));
                } catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateCustomerResponse(command.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CreateCustomerResponse(command.Id, validationResult));
        }
    }
}
