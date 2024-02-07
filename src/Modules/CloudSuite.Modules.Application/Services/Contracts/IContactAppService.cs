using CloudSuite.Modules.Application.Handlers.Contacts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IContactAppService
    {
        Task<ContactViewModel> GetByEmail(Email email);

        Task<ContactViewModel> GetByName(Name name);

        Task<ContactViewModel> GetByTelephone(Telephone telephone);
        
        Task Save(CreateContactCommand commandCreate);
    }
}
