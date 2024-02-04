using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories
{
	public class DomainRepository : IDomainRepository
	{

		protected readonly SubscriptionDbContext Db;
		protected readonly DbSet<DomainEntidade> DbSet;

		public DomainRepository(SubscriptionDbContext context)
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
