using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Requests
{
    public class CheckSubscriptionExistsByActiveRequest : IRequest<CheckSubscriptionExistsByActiveResponse>
    {
        public Guid Id { get; private set; }
        public bool Active {  get; set; }

        public CheckSubscriptionExistsByActiveRequest(bool active)
        {
            Id = Guid.NewGuid();
            Active = active;
        }
    }
}
