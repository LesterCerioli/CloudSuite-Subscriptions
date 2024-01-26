using CloudSuite.Modules.Application.Handlers.People;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IPersonAppService
    {
        Task<PersonViewmodel> GetByName(Name name);

        Task Save(CreatePersonCommand commandCreate);
         
    }
}