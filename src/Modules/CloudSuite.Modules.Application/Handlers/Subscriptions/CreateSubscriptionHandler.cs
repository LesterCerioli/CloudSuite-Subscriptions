using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.Subscription;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionCommand, CreateSubscriptionResponse>
    {
        private ISubscriptionRepository _repositorioSubscription;
        private readonly ILogger<CreateSubscriptionHandler> _logger;

        public CreateSubscriptionHandler(ISubscriptionRepository repositorioSubscription, ILogger<CreateSubscriptionHandler> logger)
        {
            _repositorioSubscription = repositorioSubscription;
            _logger = logger;
        }

        public async Task<CreateSubscriptionResponse> Handle(CreateSubscriptionCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateSubscriptionCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateSubscriptionCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try{
                    var subscriptionIsActive = await _repositorioSubscription.GetByActive(command.Active);
                    var subscriptionCreateDate = await _repositorioSubscription.GetByCreateDate(command.CreateDate);
                    var subscriptionExpireDate = await _repositorioSubscription.GetByExpireDate(command.ExpirteDate);
                    var subscriptionLastUpdateDate = await _repositorioSubscription.GetByLastUpdateDate(command.LastUpdateDate);
                    var subscriptionNumber = await _repositorioSubscription.GetBySubscriptionNumber(command.SubscriptionNumber);

                    if (subscriptionIsActive != null && subscriptionCreateDate != null && subscriptionExpireDate != null && subscriptionLastUpdateDate != null && subscriptionNumber != null)
                    {
                        return await Task.FromResult(new CreateSubscriptionResponse(command.Id, "Subscription já criada."));
                    }

                    await _repositorioSubscription.Add(command.GetEntity());
                    return await Task.FromResult(new CreateSubscriptionResponse(command.Id, validationResult));
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateSubscriptionResponse(command.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CreateSubscriptionResponse(command.Id, validationResult));
        }
    }
}