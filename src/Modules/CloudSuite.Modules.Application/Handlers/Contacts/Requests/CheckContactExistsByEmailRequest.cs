using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts.Requests
{
    public class CheckContactExistsByEmailRequest : IRequest<CheckContactExistsByEmailResponse>
    {
        public Guid Id { get; private set; }

        public string Email { get; set; }

        public CheckContactExistsByEmailRequest(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}
