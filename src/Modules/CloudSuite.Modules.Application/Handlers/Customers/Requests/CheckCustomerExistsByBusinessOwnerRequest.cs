using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByBusinessOwnerRequest : IRequest<CheckCustomerExistsByBusinessOwnerResponse>
    {
        public Guid Id {  get; private set; }
        public string? BusinessOwner { get;  set; }

        public CheckCustomerExistsByBusinessOwnerRequest(string? businessOwner)
        {
            Id = Guid.NewGuid();
            BusinessOwner = businessOwner;
        }
    }
}
