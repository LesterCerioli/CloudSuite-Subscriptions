using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        protected readonly SubscriptionDbContext Db;
        protected readonly DbSet<Payment> DbSet;

        public PaymentRepository(SubscriptionDbContext db, DbSet<Payment> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task Add(Payment payment)
        {
            await Task.Run(() => {
                DbSet.Add(payment);
                Db.SaveChanges();
            });
        }

        public async Task<Payment> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
        }

        public async Task<Payment> GetByEmail(Email email)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Payment> GetByExpireDate(DateTime? expireDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.ExpireDate == expireDate);
        }

        public async Task<Payment> GetByNumber(string number)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Number == number);
        }

        public async Task<Payment> GetByPaidDate(DateTime? paidDate)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.PaidDate == paidDate);
        }

        public async Task<Payment> GetByPayer(string payer)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Payer == payer);
        }

        public async Task<Payment> GetByTotal(decimal total)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Total == total);
        }

        public async Task<Payment> GetByTotalPaid(decimal totalPaid)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.TotalPaid == totalPaid);
        }

        public async Task<IEnumerable<Payment>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Payment payment)
        {
            DbSet.Remove(payment);
        }

        public void Update(Payment payment)
        {
            DbSet.Update(payment);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}