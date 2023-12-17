using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Customers.Responses
{
    public class CheckCustomerExistsByNameResponse : Response
    {

        public Guid RequestId {  get; private set; }
        public bool Exists {  get; set; }

        public CheckCustomerExistsByNameResponse(Guid requestId, bool exists, ValidationResult reasult)
        {
            RequestId = requestId;
            Exists = exists;

            foreach(var item in reasult.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckCustomerExistsByNameResponse(Guid requestId, string falhaValidacao) {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
