using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Subscriptions.Responses
{
    public class CheckSubscriptionExistsByCreateDateAndExpireDateResponse : Response
    {
        public Guid RequestId {  get; private set; }
        public bool Exists { get; set; }

        public CheckSubscriptionExistsByCreateDateAndExpireDateResponse(Guid requestid, bool exists, ValidationResult result) {
            RequestId = requestid;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckSubscriptionExistsByCreateDateAndExpireDateResponse(Guid requestId, string falhaValidacao) {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}