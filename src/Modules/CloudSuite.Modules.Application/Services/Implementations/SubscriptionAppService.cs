using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMediatorHandler _mediator;

        public SubscriptionAppService(
            ISubscriptionRepository subscriptionRepository,
            IMediatorHandler mediator,
            IMapper mapper
        )
        {
            _subscriptionRepository = subscriptionRepository;
            _mediator = mediator;
            _mapper = mapper;

        }
        
        
        public async Task<SubscriptionViewModel> GetByActive(bool active)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetByActive(active));
        }

        public async Task<SubscriptionViewModel> GetByCreateDate(DateTime createDate)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetByCreateDate(createDate));
        }

        public async Task<SubscriptionViewModel> GetByExpireDate(DateTime expireDate)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetByExpireDate(expireDate));
        }

        public async Task<SubscriptionViewModel> GetByLastUpdateDate(DateTime lastUpdateDeate)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetByLastUpdateDate(lastUpdateDeate));
        }

        public async Task<SubscriptionViewModel> GetBySubscriptionNumber(string subscriptionNumber)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetBySubscriptionNumber(subscriptionNumber));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateSubscriptionCommand commandCreate)
        {
            await _subscriptionRepository.Add(commandCreate.GetEntity());
        }
    }
}