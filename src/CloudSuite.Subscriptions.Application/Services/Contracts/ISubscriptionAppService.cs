using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface ISubscriptionAppService
    {
        Task<SubscriptionViewModel> GetBySubscriptionNumber(string subscriptionNumber);

        Task<SubscriptionViewModel> GetByCreateDate(DateTime createDate);

        Task<SubscriptionViewModel> GetByLastUpdateDate(DateTime lastUpdateDeate);

        Task<SubscriptionViewModel> GetByExpireDate(DateTime expireDate);

        Task<SubscriptionViewModel> GetByActive(bool active);

        //Task Save(CreateSubscriptionCommand commandCreate);
         
    }
}