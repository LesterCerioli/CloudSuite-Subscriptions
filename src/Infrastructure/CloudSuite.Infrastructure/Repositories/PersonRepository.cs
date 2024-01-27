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
    public class PersonRepository : IPersonRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Person> DbSet;

        public PersonRepository(SubscriptionDbContext db, DbSet<Person> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Person person)
        {
            await Task.Run(() => {
                DbSet.Add(person);
                Db.SaveChanges();
            });
        }

        public async Task<Person> GetByAge(string age)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Age == age);
        }

        public async Task<Person> GetByName(Name name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<IEnumerable<Person>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Person person)
        {
            DbSet.Remove(person);
        }

        public void Update(Person person)
        {
            DbSet.Update(person);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
