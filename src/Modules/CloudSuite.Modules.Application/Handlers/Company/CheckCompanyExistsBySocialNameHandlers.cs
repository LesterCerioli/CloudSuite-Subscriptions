using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validation.Payments;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsBySocialNameHandlers : IRequestHandler<CheckCompanyExistsBySocialNameRequest, CheckCompanyExistsBySocialNameResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CheckCompanyExistsBySocialNameHandlers> _logger;

        public CheckCompanyExistsBySocialNameHandlers(ICompanyRepository repositorioCompany, ILogger<CheckCompanyExistsBySocialNameHandlers> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsBySocialNameResponse> Handle(CheckCompanyExistsBySocialNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsBySocialNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsBySocialNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioCompany.GetBySocialName(request.SocialName);
                    if (payment != null)
                        return await Task.FromResult(new CheckCompanyExistsBySocialNameResponse(request.Id, true, validationResult));
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsBySocialNameResponse(request.Id, "Não foi possível processar sua solicitação."));
                }
            }
            return await Task.FromResult(new CheckCompanyExistsBySocialNameResponse(request.Id, false, validationResult));
        }
    }
}