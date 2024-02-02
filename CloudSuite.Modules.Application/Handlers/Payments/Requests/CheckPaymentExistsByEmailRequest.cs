using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByEmailRequest : IRequest<CheckPaymentExistsByEmailResponse>
    {
        public Guid Id { get; private set; }

        public string Email { get; set; }

        public CheckPaymentExistsByEmailRequest(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}
