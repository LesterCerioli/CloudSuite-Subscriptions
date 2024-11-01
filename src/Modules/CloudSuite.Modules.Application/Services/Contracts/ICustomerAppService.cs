using CloudSuite.Modules.Application.Handlers.Customers;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ICustomerAppService
    {
        Task<CustomerViewModel> GetByName(Name name);

        Task<CustomerViewModel> GetByEmail(Email email);

        Task<CustomerViewModel> GetByBusinessOwner(string BusinessOwner);

        Task<CustomerViewModel> GetByCreatedOn(DateTimeOffset createdOn);

        Task Save(CreateCustomerCommand commandCreate);
        
         
    }
}