using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Requests
{
    public class CheckSubscriptionExistsBySubscriptionNumberRequest : IRequest<CheckSubscriptionExistsBySubscriptionNumberResponse>
    {
        public Guid Id { get; private set; }
        public string? SubscriptionNumber {  get; set; }

        public CheckSubscriptionExistsBySubscriptionNumberRequest(Guid id, string subscriptionNumber)
        {
            Id = Guid.NewGuid();
            SubscriptionNumber = subscriptionNumber;
        }
    }
}