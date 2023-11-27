using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CheckCustomerExistsByBusinessOwnerHandler : IRequestHandler<CheckCustomerExistsByBusinessOwnerRequest, CheckCustomerExistsByBusinessOwnerResponse>
    {

        private ICustomerRepository _repositorioCustomer;
        private readonly ILogger<CheckCustomerExistsByBusinessOwnerHandler> _logger;

        public CheckCustomerExistsByBusinessOwnerHandler(ICustomerRepository repositorioCustomer, ILogger<CheckCustomerExistsByBusinessOwnerHandler> logger)
        {
            _repositorioCustomer = repositorioCustomer;
            _logger = logger;
        }

        public async Task<CheckCustomerExistsByBusinessOwnerResponse> Handle(CheckCustomerExistsByBusinessOwnerRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CheckCustomerExistsByBusinessOwnerRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCustomerExistsByBusinessOwnerRequestValidation.Validate(request);

            if(validationResult.IsValid )
            {
                try
                {
                    var customer = await _repositorioCustomer.GetByBusinessOwner(request.BusinessOwner);
                    if( customer != null )
                    {
                        return await Task.FromResult(new CheckCustomerExistsByBusinessOwnerResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCustomerExistsByBusinessOwnerResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
           return await Task.FromResult(new CheckCustomerExistsByBusinessOwnerResponse(request.Id, false, validationResult));
        }
    }
}
