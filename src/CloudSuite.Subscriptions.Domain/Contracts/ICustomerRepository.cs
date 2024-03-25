using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Commons.ValueObjects;

namespace CloudSuite.Subscriptions.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByName(Name name);

        Task<Customer> GetByCnpj(Cnpj cnpj);

        Task<Customer> GetByEmail(Email email);

        Task<Customer> GetByBusinessOwner(string BusinessOwner);

        Task<Customer> GetByCreatedOn(DateTimeOffset createdOn);

        Task<IEnumerable<Customer>> GetList();

        Task Add(Customer customer);

        void Update(Customer customer);

        void Remove(Customer customer);
    }
}