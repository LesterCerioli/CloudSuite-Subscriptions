using CloudSuite.Commons.ValueObjects;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Subscriptions.Domain.Contracts;
using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly SunscriptionDbContext Db;
        protected readonly DbSet<Contact> DbSet;

        public ContactRepository(SunscriptionDbContext context)
        {
            Db = context;
            DbSet = context.Contacts;

        }

        public async Task Add(Contact company)
        {
            await Task.Run(() => {
                DbSet.Add(company);
                Db.SaveChanges();
            });
        }

        public async Task<Contact> GetByEmail(Email email)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Contact> GetByName(Name name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<Contact> GetByTelephone(Telephone telephone)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Telephone == telephone);
        }

        public async Task<IEnumerable<Contact>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Contact company)
        {
            DbSet.Remove(company);
        }

        public void Update(Contact company)
        {
            DbSet.Update(company);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}