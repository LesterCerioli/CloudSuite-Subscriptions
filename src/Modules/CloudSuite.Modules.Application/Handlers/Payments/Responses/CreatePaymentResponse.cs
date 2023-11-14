using CloudSuite.Modules.Application.Core;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Payments.Responses
{
    public class CreatePaymentResponse : Response
    {
        public Guid RequestId { get; private set; }
        
        public CreatePaymentResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }
        
        public CreatePaymentResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = RequestId;
            this.AddError(falhaValidacao);
        }
    }
}