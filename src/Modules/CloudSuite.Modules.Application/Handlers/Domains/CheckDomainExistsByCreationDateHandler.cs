using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Domains
{
    public class CheckDomainExistsByCreationDateHandler : IRequestHandler<CheckDomainExistsByCreationDateRequest, CheckDomainExistsByCreationDateResponse>
    {

        private IDomainRepository _repositorioDomain;
        private readonly ILogger<CheckDomainExistsByCreationDateHandler> _logger;

        public CheckDomainExistsByCreationDateHandler(IDomainRepository repositorioDomain, ILogger<CheckDomainExistsByCreationDateHandler> logger)
        {
            _repositorioDomain = repositorioDomain;
            _logger = logger;
        }

        public async Task<CheckDomainExistsByCreationDateResponse> Handle(CheckDomainExistsByCreationDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckDomainExistsByCreationDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckDomainExistsByCreationDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var domain = await _repositorioDomain.GetByCreationDate(request.CreatedOn);
                    if(domain != null)
                    {
                        return await Task.FromResult(new CheckDomainExistsByCreationDateResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckDomainExistsByCreationDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }
            return await Task.FromResult(new CheckDomainExistsByCreationDateResponse(request.Id, false, validationResult));
        }
    }
}
