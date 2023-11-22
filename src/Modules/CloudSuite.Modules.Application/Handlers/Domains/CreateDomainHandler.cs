using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Domains
{
    public class CreateDomainHandler : IRequestHandler<CreateDomainCommand, CreateDomainResponse>
    {
        private IDomainRepository _repositorioDomain;
        private readonly ILogger<CreateDomainHandler> _logger;

        public CreateDomainHandler(IDomainRepository repositorioDomain, ILogger<CreateDomainHandler> logger)
        {
            _repositorioDomain = repositorioDomain;
            _logger = logger;
        }

        public async Task<CreateDomainResponse> Handle(CreateDomainCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateDomainCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateDomainCommandValidation().Validate(command);

            if(validationResult.IsValid )
            {
                try
                {
                    var domain = await _repositorioDomain.GetByDns(command.DNS);
                    if (domain != null)
                    {
                        return await Task.FromResult(new CreateDomainResponse(command.Id, "Domínio já foi cadastrado."));
                    }
                    await _repositorioDomain.Add(command.GetEntity());
                    return await Task.FromResult(new CreateDomainResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateDomainResponse(command.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CreateDomainResponse(command.Id, validationResult));
        }
    }
}