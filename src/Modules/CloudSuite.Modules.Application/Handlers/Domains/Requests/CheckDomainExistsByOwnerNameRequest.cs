using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Domains.Requests
{
    public class CheckDomainExistsByOwnerNameRequest : IRequest<CheckDomainExistsByOwnerNameResponse>
    {
        public Guid Id { get; private set; }
        public string? OwnerName { get; set; }

        public CheckDomainExistsByOwnerNameRequest(string ownerName) {
            Id = Guid.NewGuid();
            OwnerName = ownerName;
        }
    }
}