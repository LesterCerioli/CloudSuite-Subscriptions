using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByEmailRequest : IRequest<CheckCustomerExistsByEmailResponse>
    {
        public Guid Id {  get; private set; }
        public string? Email { get; private set; }

        public CheckCustomerExistsByEmailRequest(string? email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}
