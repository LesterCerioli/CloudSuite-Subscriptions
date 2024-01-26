using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(SubscriptionDbContext context)
        {
            Db = context;
            DbSet = context.Customers;

        }

        public async Task Add(Customer company)
        {
            await Task.Run(() => {
                DbSet.Add(company);
                Db.SaveChanges();
            });
        }

        public async Task<Customer> GetByBusinessOwner(string BusinessOwner)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.BusinessOwner == BusinessOwner);
        }

        public async Task<Customer> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
        }

        public async Task<Customer> GetByCreatedOn(DateTimeOffset createdOn)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CreatedOn == createdOn);
        }

        public async Task<Customer> GetByEmail(Email email)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Customer> GetByName(Name name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public Task<object> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}