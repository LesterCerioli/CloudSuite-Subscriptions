using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.Subscription;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions
{
    public class CheckSubscriptionExistsByCreateDateAndExpireDateHandlers : IRequestHandler<CheckSubscriptionExistsByCreateDateAndExpireDateRequest, CheckSubscriptionExistsByCreateDateAndExpireDateResponse>
    {
        private ISubscriptionRepository _repositorioSubscription;
        private readonly ILogger<CheckSubscriptionExistsByCreateDateAndExpireDateHandlers> _logger;

        public CheckSubscriptionExistsByCreateDateAndExpireDateHandlers(ISubscriptionRepository repositorioSubscription, ILogger<CheckSubscriptionExistsByCreateDateAndExpireDateHandlers> logger)
        {
             _repositorioSubscription = repositorioSubscription;
            _logger = logger;
        }

        public async Task<CheckSubscriptionExistsByCreateDateAndExpireDateResponse> Handle(CheckSubscriptionExistsByCreateDateAndExpireDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckSubscriptionExistsByCreateDateAndExpireDateREuqest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckSubscriptionExistsByCreateDateAndExpireDateValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var subscriptionCreate = await _repositorioSubscription.GetByCreateDate(request.CreateDate);
                    var subscriptionExpire = await _repositorioSubscription.GetByExpireDate(request.ExpirteDate);
                    if (subscriptionCreate == subscriptionExpire)
                    {
                        return await Task.FromResult(new CheckSubscriptionExistsByCreateDateAndExpireDateResponse(request.Id, true, validationResult));
                    }
                }catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckSubscriptionExistsByCreateDateAndExpireDateResponse(request.Id, "Não foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckSubscriptionExistsByCreateDateAndExpireDateResponse(request.Id, false, validationResult));
        }
    }
}