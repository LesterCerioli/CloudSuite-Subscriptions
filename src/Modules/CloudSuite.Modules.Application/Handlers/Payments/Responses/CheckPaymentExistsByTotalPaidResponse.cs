using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Payments.Responses
{
    public class CheckPaymentExistsByTotalPaidResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }

        public CheckPaymentExistsByTotalPaidResponse(Guid requestId, bool exists, ValidationResult result) {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckPaymentExistsByTotalPaidResponse(Guid requestId, string falhaValidacao)
        {
            RequestId=requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}