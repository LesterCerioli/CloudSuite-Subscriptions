using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Subscription : Entity, IAggregateRoot
    {

        private readonly List<Payment> _payments;

        public Subscription(DateTime? createDate, DateTime? lastUpdateDate, 
        DateTime? expireDate, bool? active, string subscriptionNumber)
        {
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            ExpireDate = expireDate;
            Active = active;
            _payments = new List<Payment>();
            SubscriptionNumber = subscriptionNumber;
        }

        public string? SubscriptionNumber { get; private set; }
        public DateTime? CreateDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool? Active { get; private set; }

        

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }
        
    }
}