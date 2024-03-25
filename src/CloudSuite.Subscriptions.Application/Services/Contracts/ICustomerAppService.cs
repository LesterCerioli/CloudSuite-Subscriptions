using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface ICustomerAppService
    {
        Task<CustomerViewModel> GetByName(Name name);

        Task<CustomerViewModel> GetByEmail(Email email);

        Task<CustomerViewModel> GetByBusinessOwner(string BusinessOwner);

        Task<CustomerViewModel> GetByCreatedOn(DateTimeOffset createdOn);

        //Task Save(CreateCustomerCommand commandCreate);
         
    }
}