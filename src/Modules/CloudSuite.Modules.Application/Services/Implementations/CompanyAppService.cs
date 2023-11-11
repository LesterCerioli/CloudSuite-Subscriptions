using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CompanyAppService(
            ICompanyRepository companyRepository,
            IMediatorHandler mediator,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _mediator = mediator;
            _companyRepository = companyRepository;
            

        }
        
        public async Task<CompanyViewModel> GetByCnpj(Cnpj cnpj)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByCnpj(cnpj));
        }

        public async Task<CompanyViewModel> GetByFantasyName(string fantasyName)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetByFantasyName(fantasyName));
        }

        public async Task<CompanyViewModel> GetBySocialName(string socialName)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetBySocialName(socialName));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public async Task Save(CreateCompanyCommand commandCreate)
        //{
            //await _companyRepository.Add(commandCreate.GetEntity());
        //}
    }
}