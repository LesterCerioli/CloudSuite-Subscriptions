using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByExpireDateRequest : IRequest<CheckPaymentExistsByExpireDateResponse>
    {
        public Guid Id { get; private set; }
        public DateTime ExpireDate { get; private set; }

        public CheckPaymentExistsByExpireDateRequest(Guid id, DateTime expireDate)
        {
            Id = Guid.NewGuid();
            ExpireDate = expireDate;
        }
    }
}
