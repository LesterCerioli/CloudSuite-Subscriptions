using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByCreatedOnRequest : IRequest<CheckCustomerExistsByCreatedOnResponse>
    {
        public Guid Id { get; private set; }
        public DateTimeOffset CreatedOn {  get; set; }

        public CheckCustomerExistsByCreatedOnRequest(DateTimeOffset createdOn)
        {
            Id = Guid.NewGuid();
            CreatedOn = createdOn;
        }
    }
}
