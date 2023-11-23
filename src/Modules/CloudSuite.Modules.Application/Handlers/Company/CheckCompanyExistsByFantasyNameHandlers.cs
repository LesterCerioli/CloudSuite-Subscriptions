using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Validation.Company;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CheckCompanyExistsByFantasyNameHandlers : IRequestHandler<CheckCompanyExistsByFantasyNameRequest, CheckCompanyExistsByFantasyNameResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CheckCompanyExistsByFantasyNameHandlers> _logger;

        public CheckCompanyExistsByFantasyNameHandlers(ICompanyRepository repositorioCompany, ILogger<CheckCompanyExistsByFantasyNameHandlers> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsByFantasyNameResponse>Handle(CheckCompanyExistsByFantasyNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsBySocialNameRequest:{JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByFantasylNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var payment = await _repositorioCompany.GetByFantasyName(request.FantasyName);
                    if(payment != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, true, validationResult));
                    }
                }catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, "Failed to process the request."));
                }
            }

            return await Task.FromResult(new CheckCompanyExistsByFantasyNameResponse(request.Id, false, validationResult));

        }
    }
}