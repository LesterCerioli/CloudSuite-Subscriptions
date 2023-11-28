using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByTotalPaidRequest : IRequest<CheckPaymentExistsByTotalPaidResponse>
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