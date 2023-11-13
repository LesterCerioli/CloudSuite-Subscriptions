using System.Runtime.InteropServices;
using CloudSuite.Modules.Application.Handlers.Persons;
using CloudSuite.Modules.Application.ViewModels;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IPersonAppService
    {
        Task<PersonViewmodel> GetByName(string name);

        Task<PersonViewmodel> GetNyAge(string age);

        Task Save(CreatePersonCommand commandCreate);

        
         
    }
}