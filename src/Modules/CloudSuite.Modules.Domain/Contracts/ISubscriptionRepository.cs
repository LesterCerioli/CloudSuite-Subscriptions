namespace CloudSuite.Modules.Domain.Contracts
{
    public interface ISubscriptionRepository
    {
        Subscription GetSubscriptionById(int id);

        IEnumerable<Subscription> GetAllSubscriptions();

        void AddSubscription(Subscription subscription);

        void UpdateSubscription(Subscription subscription);

        void RemoveSubscription(int id);
    }

    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string SubscriptionType { get; set; }
        public decimal Price { get; set; }
        // Add more properties as needed

        public Subscription(int subscriptionId, string subscriptionType, decimal price)
        {
            SubscriptionId = subscriptionId;
            SubscriptionType = subscriptionType;
            Price = price;
        }
    }
}
