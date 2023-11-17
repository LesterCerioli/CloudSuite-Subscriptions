using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICompanyAppService
    {
        Task<CompanyViewModel> GetBySocialName(string socialName);

        Task<CompanyViewModel> GetByCnpj(Cnpj cnpj);

        Task<CompanyViewModel> GetByFantasyName(string fantasyName);

        //Task Save(CreateCompanyCommand commandCreate);
         
    }
}