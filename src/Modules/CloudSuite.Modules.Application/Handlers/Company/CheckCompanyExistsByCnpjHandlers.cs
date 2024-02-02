
using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validation.Company;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsByCnpjHandlers : IRequestHandler<CheckCompanyExistsByCnpjRequest, CheckCompanyExistsByCnpjResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CheckCompanyExistsByCnpjHandlers> _logger;

        public CheckCompanyExistsByCnpjHandlers(ICompanyRepository repositorioCompany, ILogger<CheckCompanyExistsByCnpjHandlers> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsByCnpjResponse> Handle(CheckCompanyExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioCompany.GetByCnpj(new Cnpj(request.Cnpj));
                    if (payment != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckCompanyExistsByCnpjResponse(request.Id, false, validationResult));
        }
    }
}