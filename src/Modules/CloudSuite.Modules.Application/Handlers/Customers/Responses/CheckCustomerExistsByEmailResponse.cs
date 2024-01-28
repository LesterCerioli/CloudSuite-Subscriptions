using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers.Responses
{
    public class CheckCustomerExistsByEmailResponse : Response
    {

        public Guid RequestId { get; private set; }
        public bool Exists {  get; set; }

        public CheckCustomerExistsByEmailResponse(Guid requestId, bool exists, ValidationResult result)
        {
            RequestId = requestId;
            Exists = exists;
            foreach(var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckCustomerExistsByEmailResponse(Guid requestId, string falhaValidacao) {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}
