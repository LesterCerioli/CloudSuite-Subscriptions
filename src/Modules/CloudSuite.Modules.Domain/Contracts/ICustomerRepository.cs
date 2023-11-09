using CloudSuite.Modules.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(int customerId);

        Task<IEnumerable<Customer>> GetAllCustomers();

        Task AddCustomer(Customer customer);

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int customerId);
    }
}
