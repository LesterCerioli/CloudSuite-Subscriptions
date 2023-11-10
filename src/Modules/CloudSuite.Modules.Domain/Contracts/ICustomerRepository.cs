using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByName(string name);

        Task<Customer> GetByCnpj(Cnpj cnpj);

        Task<Customer> GetByEmail(string email);

        Task<Customer> GetByBusinessOwner(string BusinessOwner);

        Task<Customer> GetByCreatedOn(DateTimeOffset createdOn);

        Task<Customer> GetByCompany(Company company);

        Task<IEnumerable<Customer>> GetList();

        Task Add(Customer customer);

        void Update(Customer customer);

        void Remove(Customer customer);
    }
}
