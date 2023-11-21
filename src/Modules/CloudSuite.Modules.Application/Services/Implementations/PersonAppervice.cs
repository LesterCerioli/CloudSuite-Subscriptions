using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Persons;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class PersonAppervice : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        public PersonAppervice(
            IPersonRepository personRepository,
            IMapper mapper,
            IMediatorHandler mediator
        )
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _mediator = mediator;

        }
        
        public async Task<PersonViewmodel> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonViewmodel> GetNyAge(string age)
        {
            throw new NotImplementedException();
        }

        public Task Save(CreatePersonCommand commandCreate)
        {
            throw new NotImplementedException();
        }
    }
}