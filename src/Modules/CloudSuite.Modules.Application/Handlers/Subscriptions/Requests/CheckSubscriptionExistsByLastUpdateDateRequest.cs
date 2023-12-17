using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Requests
{
    public class CheckSubscriptionExistsByLastUpdateDateRequest : IRequest<CheckSubscriptionExistsByLastUpdateDateResponse>
    {
        public Guid Id {  get; private set; }
        public DateTime LastUpdateDate {  get; set; }

        public CheckSubscriptionExistsByLastUpdateDateRequest(DateTime lastUpdateDate)
        {
            Id = Guid.NewGuid();
            LastUpdateDate = lastUpdateDate;
        }
    }
}
