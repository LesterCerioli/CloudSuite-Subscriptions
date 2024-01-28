using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts
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
