using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts.Requests
{
    public class CheckContactExistsByNameRequest : IRequest<CheckContactExistsByNameResponse>
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public CheckContactExistsByNameRequest(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
