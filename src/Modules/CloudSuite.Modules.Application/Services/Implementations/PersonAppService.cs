using AutoMapper;
using CloudSuite.Modules.Application.Handlers.People;
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
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler _mediator;

        public PersonAppService(
            IPersonRepository personRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PersonViewmodel> GetByName(Name name)
        {
            return _mapper.Map<PersonViewmodel>(await _personRepository.GetByName(name));   
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreatePersonCommand commandCreate)
        {
            await _personRepository.Add(commandCreate.GetEntity());
        }
    }
}
