using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IContactRepository
    {
        Task<Contact> GetByTelephone(Telephone telephone);

        Task<Contact> GetByName(Name name);

        Task<Contact> GetByEmail(Email email);

        Task<IEnumerable<Contact>> GetList();

        Task Add(Contact contact);

        void Update(Contact contact);

        void Remove(Contact contact);
    }
}
