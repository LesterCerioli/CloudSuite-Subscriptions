using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<DomainEntidade> DbSet;

        public DomainRepository(SubscriptionDbContext db, DbSet<DomainEntidade> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(DomainEntidade domain)
        {
            await Task.Run(() => {
                DbSet.Add(domain);
                Db.SaveChanges();
            });
        }

        public async Task<DomainEntidade> GetByCreationDate(DateTimeOffset creationDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CreationDate == creationDate);
        }

        public async Task<DomainEntidade> GetByDns(string dns)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.DNS == dns);
        }

        public async Task<DomainEntidade> GetByOwnerName(string ownerName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.OwnerName == ownerName);
        }

        public async Task<IEnumerable<DomainEntidade>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void RemoveDomainEntity(DomainEntidade domain)
        {
            DbSet.Remove(domain);
        }

        public void UpdateDomainEntity(DomainEntidade domain)
        {
            DbSet.Update(domain);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}