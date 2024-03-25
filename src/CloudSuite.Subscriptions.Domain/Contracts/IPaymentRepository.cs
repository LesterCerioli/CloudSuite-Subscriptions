using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Domain.Models;

namespace CloudSuite.Subscriptions.Domain.Contracts
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByNumber(string number);

        Task<Payment> GetByPaidDate(DateTime? paidDate);

        Task<Payment> GetByExpireDate(DateTime? expireDate);

        Task<Payment> GetByTotal(decimal total);

        Task<Payment> GetByTotalPaid(decimal totalPaid);

        Task<Payment> GetByPayer(string payer);

        Task<Payment> GetByCnpj(Cnpj cnpj);

        Task<Payment> GetByEmail(Email email);

        Task<IEnumerable<Payment>> GetList();

        Task Add(Payment payment);

        void Update(Payment payment);

        void Remove(Payment payment);
         
    }
}