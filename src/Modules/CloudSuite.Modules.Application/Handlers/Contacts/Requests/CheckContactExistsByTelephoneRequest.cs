using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts.Requests
{
    public class CheckContactExistsByTelephoneRequest : IRequest<CheckContactExistsByTelephoneResponse>
    {
        public Guid Id { get; private set; }

        public string Telephone { get; set; }

        public CheckContactExistsByTelephoneRequest(string telephone)
        {
            Id = Guid.NewGuid();
            Telephone = telephone;
        }
    }
}
