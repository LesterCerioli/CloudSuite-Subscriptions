using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Responses
{
    public class CreateSubscriptionResponse : Response {
        public Guid RequestId { get; private set; }

        public CreateSubscriptionResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateSubscriptionResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            this.AddError(falhaValidacao);
        }
    }
}
