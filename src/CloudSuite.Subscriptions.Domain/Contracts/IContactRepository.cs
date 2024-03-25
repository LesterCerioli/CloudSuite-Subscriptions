using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Domain.Models;

namespace CloudSuite.Subscriptions.Domain.Contracts
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