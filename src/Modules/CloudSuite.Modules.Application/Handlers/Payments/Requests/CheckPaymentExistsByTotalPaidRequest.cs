namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByTotalPaidRequest
    {
        public Guid id { get; private set; }
        
        public decimal? TotalPaid { get; private set;}

        public CheckPaymentExistsByTotalPaidRequest(decimal totalPaid)
        {
            Id = Guid.NewGuid();
            TotalPaid = totalPaid;
        }

    }
}