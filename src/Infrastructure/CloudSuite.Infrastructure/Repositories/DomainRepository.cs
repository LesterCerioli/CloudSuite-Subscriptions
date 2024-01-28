using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Domain> DbSet;

        public DomainRepository(SubscriptionDbContext db, DbSet<Domain> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Domain domain)
        {
            await Task.Run(() => {
                DbSet.Add(domain);
                Db.SaveChanges();
            });
        }

        public async Task<Domain> GetByCreationDate(DateTimeOffset creationDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CreationDate == creationDate);
        }

        public async Task<Domain> GetByDns(string dns)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.DNS == dns);
        }

        public async Task<Domain> GetByOwnerName(string ownerName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.OwnerName == ownerName);
        }

        public async Task<IEnumerable<Domain>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void RemoveDomainEntity(Domain domain)
        {
            DbSet.Remove(domain);
        }

        public void UpdateDomainEntity(Domain domain)
        {
            DbSet.Update(domain);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}