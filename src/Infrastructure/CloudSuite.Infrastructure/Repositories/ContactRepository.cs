using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Contact> DbSet;

        public ContactRepository(SubscriptionDbContext context)
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

        public async Task<Contact> GetByEmail(string email)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Contact> GetByNumber(string number)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Number == number);
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
