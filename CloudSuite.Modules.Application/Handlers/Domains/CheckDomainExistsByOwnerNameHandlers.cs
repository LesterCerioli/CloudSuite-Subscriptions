using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using CloudSuite.Modules.Application.Validation.Domains;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Domains
{
    public class CheckDomainExistsByOwnerNameHandlers : IRequestHandler<CheckDomainExistsByOwnerNameRequest, CheckDomainExistsByOwnerNameResponse>
    {
        private IDomainRepository _repositorioDomain;
        private readonly ILogger<CheckDomainExistsByOwnerNameHandlers> _logger;

        public CheckDomainExistsByOwnerNameHandlers(IDomainRepository repositorioDomain, ILogger<CheckDomainExistsByOwnerNameHandlers> logger)
        {
            _repositorioDomain = repositorioDomain;
            _logger = logger;
        }

        public async Task<CheckDomainExistsByOwnerNameResponse> Handle(CheckDomainExistsByOwnerNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckDomainExistsByOwnerNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckDomainExistsByOwnerNameRequestValidation().Validate(request);

            if(validationResult.IsValid){
                try
                {
                    var domain = await _repositorioDomain.GetByOwnerName(request.OwnerName);
                    if (domain != null)
                    {
                        return await Task.FromResult(new CheckDomainExistsByOwnerNameResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckDomainExistsByOwnerNameResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckDomainExistsByOwnerNameResponse(request.Id, false, validationResult));
        }
    }
}