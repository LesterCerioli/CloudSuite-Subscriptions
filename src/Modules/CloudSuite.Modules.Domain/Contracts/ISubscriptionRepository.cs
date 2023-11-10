using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts;

public interface ISubscriptionRepository
{
    Task<Subscription> GetBySubscriptionNumber(string subscriptionNumber);

    Task<Subscription> GetByCreateDate(DateTime createDate);

    Task<Subscription> GetByLastUpdateDate(DateTime lastUpdateDeate);

    Task<Subscription> GetByExpireDate(DateTime expireDate);

    Task<Subscription> GetByActive(bool active);
}
