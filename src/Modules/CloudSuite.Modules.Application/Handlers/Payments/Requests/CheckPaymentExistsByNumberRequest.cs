using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByNumberRequest
    {
        public class CheckExistsPaymentByNumberRequest : IRequest<CheckExistsPaymentByNumberRequest>
        {
            public Guid Id { get; private set; }

            public string Number { get; private set; }

            public CheckExistsPaymentByNumberRequest(string number)
            {
                Id = Guid.NewGuid();
                Number = number;
            }
        }
    }
}