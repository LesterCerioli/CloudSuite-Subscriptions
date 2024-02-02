using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByTotalRequest : IRequest<CheckPaymentExistsByTotalResponse>
    {
        public Guid Id {  get; private set; }
        public decimal Total {  get; private set; }
         
        public CheckPaymentExistsByTotalRequest(decimal total)
        {
            Id = Guid.NewGuid();
            Total = total;
        }
    }
}
