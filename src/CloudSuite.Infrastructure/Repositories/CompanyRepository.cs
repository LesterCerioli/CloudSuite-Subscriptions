using CloudSuite.Commons.ValueObjects;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Subscriptions.Domain.Contracts;
using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        
        protected readonly SunscriptionDbContext Db;
        protected readonly DbSet<Company> DbSet;
        
        public CompanyRepository(SunscriptionDbContext context)
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