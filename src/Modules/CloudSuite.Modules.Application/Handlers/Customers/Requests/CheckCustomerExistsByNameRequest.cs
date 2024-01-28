using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByNameRequest : IRequest<CheckCustomerExistsByNameResponse>
    {
        public Guid Id {  get; private set; }
        public string? Name { get; set; }

        public CheckCustomerExistsByNameRequest(string? name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
