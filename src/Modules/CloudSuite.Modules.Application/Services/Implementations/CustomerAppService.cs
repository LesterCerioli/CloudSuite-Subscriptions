using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
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

        public async Task<CustomerViewModel> GetByEmail(Email email)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByEmail(email));
        }

        public async Task<CustomerViewModel> GetByName(Name name)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByName(name));
        }

        public async Task<CustomerViewModel> GetByCnpj(Cnpj cnpj)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetByCnpj(cnpj));
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

		public async Task Save(CreateCustomerCommand commandCreate)
		{
            await _customerRepository.Add(commandCreate.GetEntity());
		}
    }
}