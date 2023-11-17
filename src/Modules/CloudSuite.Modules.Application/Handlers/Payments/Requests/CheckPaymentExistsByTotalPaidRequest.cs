using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByTotalPaidRequest : IRequest<CheckPaymentExistsByTotalPaidRequest>
    {
        public Guid Id { get; private set; }

        public decimal? TotalPaid { get; private set; }

        public CheckPaymentExistsByTotalPaidRequest(decimal totalPaid)
        {
            Id = Guid.NewGuid();
            TotalPaid = totalPaid;
        }

    }
}