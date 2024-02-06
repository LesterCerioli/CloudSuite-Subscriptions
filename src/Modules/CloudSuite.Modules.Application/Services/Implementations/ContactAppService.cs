using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Contacts;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;


namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class ContactAppService : IContactAppService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ContactAppService(IContactRepository contactRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ContactViewModel> GetByEmail(string email)
        {
            return _mapper.Map<ContactViewModel>(await _contactRepository.GetByEmail(email));
        }

        public async Task<ContactViewModel> GetByNumber(string number)
        {
            return _mapper.Map<ContactViewModel>(await _contactRepository.GetByNumber(number));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
        public async Task Save(CreateContactCommand commandCreate)
        {
            await _contactRepository.Add(commandCreate.GetEntity());
        }
 
    }
}
