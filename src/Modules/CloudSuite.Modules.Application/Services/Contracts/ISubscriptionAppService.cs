using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ISubscriptionAppService
    {
        Task<SubscriptionViewModel> GetBySubscriptionNumber(string subscriptionNumber);

        Task<SubscriptionViewModel> GetByCreateDate(DateTime createDate);

        Task<SubscriptionViewModel> GetByLastUpdateDate(DateTime lastUpdateDeate);

        Task<SubscriptionViewModel> GetByExpireDate(DateTime expireDate);

        Task<SubscriptionViewModel> GetByActive(bool active);

        Task Save(CreateSubscriptionCommand commandCreate);
		
        Task ProcessSubscriptionService();
		
        
	}
}