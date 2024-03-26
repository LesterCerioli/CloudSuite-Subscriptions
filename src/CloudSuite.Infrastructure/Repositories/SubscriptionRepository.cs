using CloudSuite.Infrastructure.Context;
using CloudSuite.Subscriptions.Domain.Contracts;
using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        protected readonly SunscriptionDbContext Db;
        protected readonly DbSet<Subscription> DbSet;

        public SubscriptionRepository(SunscriptionDbContext db, DbSet<Subscription> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Subscription subscription)
        {
            await Task.Run(() => {
                DbSet.Add(subscription);
                Db.SaveChanges();
            });
        }

        public async Task<Subscription> GetByActive(bool active)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Active == active);
        }

        public async Task<Subscription> GetByCreateDate(DateTime createDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CreateDate == createDate);
        }

        public async Task<Subscription> GetByExpireDate(DateTime expireDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.ExpireDate == expireDate);
        }

        public async Task<Subscription> GetByLastUpdateDate(DateTime lastUpdateDeate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.LastUpdateDate == lastUpdateDeate);
        }

        public async Task<Subscription> GetBySubscriptionNumber(string subscriptionNumber)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.SubscriptionNumber == subscriptionNumber);
        }

        public async Task<IEnumerable<Subscription>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Subscription subscription)
        {
            DbSet.Remove(subscription);
        }

        public void Update(Subscription subscription)
        {
            DbSet.Remove(subscription);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}