using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Requests
{
    public class CheckSubscriptionExistsByCreateDateAndExpireDateRequest : IRequest<CheckSubscriptionExistsByCreateDateAndExpireDateResponse>
    {
        public Guid Id { get; private set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ExpirteDate { get; set; }

        public CheckSubscriptionExistsByCreateDateAndExpireDateRequest(DateTime? createDate, DateTime? expireDate) {
            Id = Guid.NewGuid();
            CreateDate = createDate;
            ExpirteDate = expireDate;

        }
    }
}