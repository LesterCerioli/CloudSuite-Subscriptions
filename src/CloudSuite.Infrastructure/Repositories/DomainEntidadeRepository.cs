using CloudSuite.Infrastructure.Context;
using CloudSuite.Subscriptions.Domain.Contracts;
using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DomainEntidadeRepository : IDomainRepository
    {
        protected readonly SunscriptionDbContext Db;
		protected readonly DbSet<DomainEntidade> DbSet;

		public DomainEntidadeRepository(SunscriptionDbContext context)
		{
			Db = context;
			DbSet = context.Domains;

		}

		public async Task Add(DomainEntidade domainEntidade)
		{
			await Task.Run(() => {
				DbSet.Add(domainEntidade);
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

		public void Remove(DomainEntidade domainEntidade)
		{
			DbSet.Remove(domainEntidade);
		}

		public void Update(DomainEntidade domainEntidade)
		{
			DbSet.Remove(domainEntidade);
		}

		public void Dispose()
		{
			Db.Dispose();
		}
    }
}