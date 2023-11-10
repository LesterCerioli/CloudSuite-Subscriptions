using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICustomerAppService
    {
        Task<CustomerViewModel> GetByName(string name);

        Task<CustomerViewModel> GetByEmail(string email);

        Task<CustomerViewModel> GetByBusinessOwner(string BusinessOwner);

        Task<CustomerViewModel> GetByCreatedOn(DateTimeOffset createdOn);

        Task<CustomerViewModel> GetByCompany(Company company);
         
    }
}