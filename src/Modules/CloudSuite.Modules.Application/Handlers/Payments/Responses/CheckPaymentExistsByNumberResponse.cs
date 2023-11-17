using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Payments.Responses
{
    public class CheckPaymentExistsByNumberResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }
        public CheckPaymentExistsByNumberResponse(Guid requestId, bool exists, ValidationResult result) {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckPaymentExistsByNumberResponse(Guid requestId, string falhaValidacao) {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}