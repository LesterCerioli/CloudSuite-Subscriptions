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

    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        // Add more properties as needed

        public Payment(int paymentId, string paymentMethod, decimal amount)
        {
            PaymentId = paymentId;
            PaymentMethod = paymentMethod;
            Amount = amount;
        }
    }
}
