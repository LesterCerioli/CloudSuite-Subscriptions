using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers.Responses
{
    public class CreateCustomerResponse : Response
    {

		public Guid RequestId { get; private set; }

		public CreateCustomerResponse(Guid requestId, ValidationResult result)
		{
			RequestId = requestId;
			foreach (var item in result.Errors)
			{
				this.AddError(item.ErrorMessage);
			}
		}

		public CreateCustomerResponse(Guid requestId, string failValidation)
		{
			RequestId = requestId;
			this.AddError(failValidation);
		}
	}
}
