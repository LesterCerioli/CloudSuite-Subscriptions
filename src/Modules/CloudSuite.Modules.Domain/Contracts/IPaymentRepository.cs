using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Contracts
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
