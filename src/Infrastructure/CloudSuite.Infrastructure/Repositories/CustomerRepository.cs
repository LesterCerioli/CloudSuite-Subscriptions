using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByBusinessOwner(string BusinessOwner)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByCnpj(Cnpj cnpj)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByCreatedOn(DateTimeOffset createdOn)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}