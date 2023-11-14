using CloudSuite.Modules.Application.Core;
using System.ComponentModel.DataAnnotations;

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

        public CheckPaymentExistsByCnpjResponse(Guid requestId, string falhaValidacao) {
            RequestId = requestId;
            Exists = falhaValidacao;
            this.AddError(falhaValidacao);
        }
    }
}