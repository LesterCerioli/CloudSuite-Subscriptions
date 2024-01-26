using System.Data.Common;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Company> DbSet;
        
        public CompanyRepository(SubscriptionDbContext context)
        {
            Db = context;
            DbSet = context.Companies; 

        }

        public async Task Add(Company company)
        {
            await Task.Run(() => { 
                DbSet.Add(company);
                Db.SaveChanges();
            });
        }

        public async Task<Company> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
        }

        public async Task<Company> GetByFantasyName(string fantasyName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.FantasyName == fantasyName);
        }

        public async Task<Company> GetBySocialName(string socialName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.SocialName == socialName);
        }

        public async Task<IEnumerable<Company>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Company company)
        {
            DbSet.Remove(company);
        }

        public void Update(Company company)
        {
            DbSet.Update(company);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}