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
}
