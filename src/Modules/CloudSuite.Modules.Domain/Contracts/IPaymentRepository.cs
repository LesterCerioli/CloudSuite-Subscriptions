namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IPaymentRepository
    {
        Payment GetPaymentById(int id);

        IEnumerable<Payment> GetAllPayments();

        void AddPayment(Payment payment);

        void UpdatePayment(Payment payment);

        void RemovePayment(int id);
    }
}
