using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using SubscriptionEntity = CloudSuite.Modules.Domain.Models.Subscription;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions
{
    public class CreateSubscriptionCommand : IRequest<CreateSubscriptionResponse>
    {
        public Guid Id {  get; private set; }
        public string? SubscriptionNumber { get; set; }
        public DateTime? CreateDate {  get; set; }
        public DateTime? LastUpdateDate { get; set;}
        public DateTime? ExpirteDate { get; set; }
        public bool? Active {  get; set; }

        public CreateSubscriptionCommand()
        {
            Id = Guid.NewGuid();
        }

        public SubscriptionEntity GetEntity()
        {
            return new SubscriptionEntity(
                this.CreateDate,
                this.LastUpdateDate,
                this.ExpirteDate,
                this.Active,
                this.SubscriptionNumber
                );
        }
    }
}