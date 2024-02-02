using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByPayerRequest : IRequest<CheckPaymentExistsByPayerResponse>
    {
        public Guid Id {  get; private set; }
        public string Payer {  get; private set; }

        public CheckPaymentExistsByPayerRequest(string payer)
        {
            Id = Guid.NewGuid();
            Payer = payer;
        }
    }
}
