using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByPaidDateRequest : IRequest<CheckPaymentExistsByPaidDateResponse>
    {
        public Guid Id { get; private set; }
        public DateTime PaidDate { get; private set; }

        public CheckPaymentExistsByPaidDateRequest(DateTime paidDate)
        {
            Id = Guid.NewGuid();
            PaidDate = paidDate;
        }
    }
}
