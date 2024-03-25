using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface IComnpanyAppService
    {
        Task<CompanyViewModel> GetBySocialName(string socialName);

        Task<CompanyViewModel> GetByCnpj(Cnpj cnpj);

        Task<CompanyViewModel> GetByFantasyName(string fantasyName);

        //Task Save(CreateCompanyCommand commandCreate);
         
    }
}