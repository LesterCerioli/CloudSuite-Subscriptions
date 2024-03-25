using CloudSuite.Subscriptions.Application.ViewModels;

namespace CloudSuite.Subscriptions.Application.Services.Contracts
{
    public interface IDomainAppService
    {
        Task<DomainViewModel> GetByDns(string dns);

        Task<DomainViewModel> GetByOwnerName(string ownerName);

        Task<DomainViewModel> GetByCreationDate(DateTimeOffset creationDate);

        //Task Save(CreateDomainCommand commandCreate);
         
    }
}