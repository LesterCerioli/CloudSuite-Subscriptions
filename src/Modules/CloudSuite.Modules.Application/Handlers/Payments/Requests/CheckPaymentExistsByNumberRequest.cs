using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByNumberRequest : IRequest<CheckPaymentExistsByNumberResponse>
    {
        public Guid Id { get; private set; }

        public string Number { get; private set; }

        public CheckPaymentExistsByNumberRequest(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }
    }
}