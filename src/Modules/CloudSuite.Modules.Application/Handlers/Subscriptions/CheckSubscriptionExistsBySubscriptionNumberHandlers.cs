
using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.Subscription;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions
{
    public class CheckSubscriptionExistsBySubscriptionNumberHandlers : IRequestHandler<CheckSubscriptionExistsBySubscriptionNumberRequest, CheckSubscriptionExistsBySubscriptionNumberResponse>
    {

        private ISubscriptionRepository _repositorioSubscription;
        private readonly ILogger<CheckSubscriptionExistsBySubscriptionNumberHandlers> _logger;

        public CheckSubscriptionExistsBySubscriptionNumberHandlers(ISubscriptionRepository repositorioSubscription, ILogger<CheckSubscriptionExistsBySubscriptionNumberHandlers> logger)
        {
            _repositorioSubscription = repositorioSubscription;
            _logger = logger;
        }

        public async Task<CheckSubscriptionExistsBySubscriptionNumberResponse> Handle(CheckSubscriptionExistsBySubscriptionNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckSubscriptionExistsBySubscriptionNumberRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckSubscriptionExistsBySubscriptionNumberValidation().Validate(request);

            if(validationResult.IsValid)
            {
                try
                {
                    var subscription = await _repositorioSubscription.GetBySubscriptionNumber(request.SubscriptionNumber);

                    if (subscription != null)
                    {
                        return await Task.FromResult(new CheckSubscriptionExistsBySubscriptionNumberResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckSubscriptionExistsBySubscriptionNumberResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckSubscriptionExistsBySubscriptionNumberResponse(request.Id, false, validationResult));
        }
    }
}