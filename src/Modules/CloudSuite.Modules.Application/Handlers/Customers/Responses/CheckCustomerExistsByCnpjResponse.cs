using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Customers.Responses
{
    public class CheckCustomerExistsByCnpjResponse : Response
    {
        public Guid RequestId { get; private set; }
        
        public bool Exists { get; set; }

        public CheckCustomerExistsByCnpjResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;

            foreach (var failure in result.Errors)
            {
                this.AddError(failure.ErrorMessage);
            }
        }

        public CheckCustomerExistsByCnpjResponse(Guid requestId, string validationFailure)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(validationFailure);
        }
    }
}


