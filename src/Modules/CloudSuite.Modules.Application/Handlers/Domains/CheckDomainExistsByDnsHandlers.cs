using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using CloudSuite.Modules.Application.Validation.Domains;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Domains
{
    public class CheckDomainExistsByDnsHandlers : IRequestHandler<CheckDomainExistsByDnsRequest, CheckDomainExistsByDnsResponse>
    {
        private IDomainRepository _repositorioDomain;
        private readonly ILogger<CheckDomainExistsByDnsHandlers> _logger;

        public CheckDomainExistsByDnsHandlers(IDomainRepository repositorioDomain, ILogger<CheckDomainExistsByDnsHandlers> logger)
        {
            _repositorioDomain = repositorioDomain;
            _logger = logger;
        }

        public async Task<CheckDomainExistsByDnsResponse> Handle(CheckDomainExistsByDnsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckDomainExistsByDnsRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckDomainExistsByDnsRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var domain = await _repositorioDomain.GetByDns(request.DNS);
                    if(domain != null)
                    {
                        return await Task.FromResult(new CheckDomainExistsByDnsResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckDomainExistsByDnsResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckDomainExistsByDnsResponse(request.Id, false, validationResult));

        }
    }
}