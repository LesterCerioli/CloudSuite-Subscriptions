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
        Task<Contact> GetByEmail(string email);

        Task<Contact> GetByNumber(string number);

        Task<IEnumerable<Contact>> GetList();

        Task Add(Contact company);

        void Update(Contact company);

        void Remove(Contact company);
    }
}
