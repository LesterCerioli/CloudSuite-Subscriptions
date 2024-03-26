using CloudSuite.Commons.ValueObjects;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Subscriptions.Domain.Contracts;
using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly SunscriptionDbContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(SunscriptionDbContext context)
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

        public async Task<IEnumerable<Customer>> GetList()
        {
            return await DbSet.ToListAsync();
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