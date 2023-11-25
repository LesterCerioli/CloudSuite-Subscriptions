using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CreateCompanyHandler> _logger;

        public CreateCompanyHandler(ICompanyRepository repositorioCompany, ILogger<CreateCompanyHandler> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand command, CancellationToken cancellationToken){
            _logger.LogInformation($"CreateCompanyCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCompanyCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioCompany.GetByCnpj(new Cnpj(command.Cnpj));
                    if (payment != null)
                    {
                        return await Task.FromResult(new CreateCompanyResponse(command.Id, "Compania já cadastrado."));
                    }
                    await _repositorioCompany.Add(command.GetEntity());
                    return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));
                }catch (Exception ex) {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateCompanyResponse(command.Id, "Não foi possível processar sua solicitação."));
                }
            }

            return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));

        }
    }
}