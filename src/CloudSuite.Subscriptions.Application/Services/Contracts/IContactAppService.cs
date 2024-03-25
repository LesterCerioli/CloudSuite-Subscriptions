using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface IContactAppService
    {
        Task<ContactViewModel> GetByEmail(Email email);

        Task<ContactViewModel> GetByName(Name name);

        Task<ContactViewModel> GetByTelephone(Telephone telephone);
        
        //Task Save(CreateContactCommand commandCreate);
         
    }
}