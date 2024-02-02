using CloudSuite.Modules.Application.Handlers.Domains;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IDomainAppService
    {
        Task<DomainViewModel> GetByDns(string dns);

        Task<DomainViewModel> GetByOwnerName(string ownerName);

        Task<DomainViewModel> GetByCreationDate(DateTimeOffset creationDate);

        Task Save(CreateDomainCommand commandCreate);
         
    }
}