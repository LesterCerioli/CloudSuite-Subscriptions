using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts.Requests
{
    public class CheckContactExistsByNumberRequest : IRequest<CheckContactExistsByNumberResponse>
    {
        public Guid Id { get; private set; }

        public string Number { get; set; }

        public CheckContactExistsByNumberRequest(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }
    }
}
