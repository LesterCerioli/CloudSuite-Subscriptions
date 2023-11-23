using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(
            ICustomerRepository customerRepository,
            IMapper mapper,
            IMediatorHandler mediator
        )
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _mediator = mediator;

        }
        
        public async Task<CustomerViewModel> GetByBusinessOwner(string businessOwner)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByBusinessOwner(businessOwner));
        }

        public async Task<CustomerViewModel> GetByCreatedOn(DateTimeOffset createdOn)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByCreatedOn(createdOn));
        }

        public async Task<CustomerViewModel> GetByEmail(string email)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByEmail(email));
        }

        public async Task<CustomerViewModel> GetByName(string name)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByName(name));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

		public Task Save(CreateCustomerCommand commandCreate)
		{
			throw new NotImplementedException();
		}

		
	}
}