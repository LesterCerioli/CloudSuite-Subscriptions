using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class ContactAppService : IContactAppService
    {
        private readonly IContactAppService _contactRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ContactAppService(IContactAppService contactRepository, IMapper mapper, IMediatorHandler mediator)
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

        /*
        public async Task Save(CreateContactCommand commandCreate)
        {
            await _contactRepository.Add(commandCreate.GetEntity());
        }
        */
    }
}
