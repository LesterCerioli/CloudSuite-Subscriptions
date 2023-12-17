using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Domain.Models;
using MediatR;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class DomainAppService : IDomainAppService
    {
        private readonly IMapper _mapper;
        private readonly IDomainRepository _domainRepository;
        private readonly IMediatorHandler _mediator;

        public DomainAppService(
            IDomainRepository domainRepository,
            IMapper mapper,
            IMediatorHandler mediator
        )
        {
            _domainRepository = domainRepository;
            _mediator = mediator;
            _mapper = mapper;

        }
        
        public async Task<DomainViewModel> GetByCreationDate(DateTimeOffset creationDate)
        {
            return _mapper.Map<DomainViewModel>(await _domainRepository.GetByCreationDate(creationDate));
        }

        public async Task<DomainViewModel> GetByDns(string dns)
        {
            return _mapper.Map<DomainViewModel>(await _domainRepository.GetByDns(dns));
        }

        public async Task<DomainViewModel> GetByOwnerName(string ownerName)
        {
            return _mapper.Map<DomainViewModel>(await _domainRepository.GetByOwnerName(ownerName));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateDomainCommand commandCreate)
        {
			await _domainRepository.Add(commandCreate.GetEntity());
		}
    }
}