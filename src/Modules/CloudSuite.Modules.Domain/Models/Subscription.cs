using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Subscription : Entity, IAggregateRoot
    {
		public Subscription(string? subscriptionNumber, DateTime? createDate, DateTime? lastUpdateDate, DateTime? expireDate, bool? active)
		{
			SubscriptionNumber = subscriptionNumber;
            CreateDate = DateTime.Now;
			LastUpdateDate = DateTime.Now;
			ExpireDate = DateTime.Now;
			Active = active;
            _payments = new List<Payment>();
		}

		public Subscription(DateTime createDate, DateTime lastUpdateDate, DateTime expirteDate, bool active, string? subscriptionNumber)
		{
			CreateDate = createDate;
			LastUpdateDate = lastUpdateDate;
			this.expirteDate = expirteDate;
			Active = active;
			SubscriptionNumber = subscriptionNumber;
		}

		public string? SubscriptionNumber { get; private set; }
        
        public DateTime? CreateDate { get; private set; }
        
        public DateTime? LastUpdateDate { get; private set; }
        
        public DateTime? ExpireDate { get; private set; }
        
        public bool? Active { get; private set; }

		private readonly List<Payment> _payments;
		private DateTime expirteDate;

		public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }
        
    }
}