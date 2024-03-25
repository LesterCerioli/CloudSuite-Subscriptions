using CloudSuite.Subscriptions.Domain.Models;

amespace CloudSuite.Subscriptions.Domain.Contracts
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> GetBySubscriptionNumber(string subscriptionNumber);

        Task<Subscription> GetByCreateDate(DateTime createDate);

        Task<Subscription> GetByLastUpdateDate(DateTime lastUpdateDeate);

        Task<Subscription> GetByExpireDate(DateTime expireDate);

        Task<Subscription> GetByActive(bool active);

        Task<IEnumerable<Subscription>> GetList();

        Task Add(Subscription subscription);

        void Update(Subscription subscription);

        void Remove(Subscription subscription);
    }
}