using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts.Responses
{
    public class CreateContactResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateContactResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }
        }

        public CreateContactResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            this.AddError(falhaValidacao);
        }
    }
}
