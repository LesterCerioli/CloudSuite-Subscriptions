using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions
{
    public class CheckSubscriptionExistsByActiveHandler : IRequestHandler<CheckSubscriptionExistsByActiveRequest, CheckSubscriptionExistsByActiveResponse>
    {

        private ISubscriptionRepository _repositorioSubscruiption;
        private readonly ILogger<CheckSubscriptionExistsByActiveHandler> _logger;

        public CheckSubscriptionExistsByActiveHandler(ISubscriptionRepository repositorioSubscruiption, ILogger<CheckSubscriptionExistsByActiveHandler> logger)
        {
            _repositorioSubscruiption = repositorioSubscruiption;
            _logger = logger;
        }

        public async Task<CheckSubscriptionExistsByActiveResponse> Handle(CheckSubscriptionExistsByActiveRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckSubscriptionExistsByAcitveRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckSubscriptionExistsByActiveRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var subscription = await _repositorioSubscruiption.GetByActive(request.Active);
                    if (subscription != null)
                    {
                        return await Task.FromResult(new CheckSubscriptionExistsByActiveResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckSubscriptionExistsByActiveResponse(request.Id, "Não foi possível processar a solicatação"));
                }
            }


            return await Task.FromResult(new CheckSubscriptionExistsByActiveResponse(request.Id, false, validationResult));
        }
    }
}
