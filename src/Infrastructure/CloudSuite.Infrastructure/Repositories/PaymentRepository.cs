using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task Add(Payment payment)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByCnpj(Cnpj cnpj)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByExpireDate(DateTime? expireDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByPaidDate(DateTime? paidDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByPayer(string payer)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByTotal(decimal total)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetByTotalPaid(decimal totalPaid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Payment>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}