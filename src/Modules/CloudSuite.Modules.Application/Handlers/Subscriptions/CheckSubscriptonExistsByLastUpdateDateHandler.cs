using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.Subscription;
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
    public class CheckSubscriptonExistsByLastUpdateDateHandler : IRequestHandler<CheckSubscriptionExistsByLastUpdateDateRequest, CheckSubscriptionExistsByLastUpdateDateResponse>
    {

        private ISubscriptionRepository _repositorioSubscription;
        private readonly ILogger<CheckSubscriptonExistsByLastUpdateDateHandler> _logger;

        public CheckSubscriptonExistsByLastUpdateDateHandler(ISubscriptionRepository repositorioSubscription, ILogger<CheckSubscriptonExistsByLastUpdateDateHandler> logger)
        {
            _repositorioSubscription = repositorioSubscription;
            _logger = logger;
        }

        public async Task<CheckSubscriptionExistsByLastUpdateDateResponse> Handle(CheckSubscriptionExistsByLastUpdateDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckSubscriptionExistsByLastUpdateDateRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckSubscriptionExistsByLastUpdateDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try {
                    var subscription = await _repositorioSubscription.GetByLastUpdateDate(request.LastUpdateDate);

                    if (subscription != null)
                    {
                        return await Task.FromResult(new CheckSubscriptionExistsByLastUpdateDateResponse(request.Id, true,validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckSubscriptionExistsByLastUpdateDateResponse(request.Id, "N~ao foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckSubscriptionExistsByLastUpdateDateResponse(request.Id, false, validationResult));
        }
    }
}
