using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using MediatR;
using DomainEntity = CloudSuite.Modules.Domain.Models.Domain;

namespace CloudSuite.Modules.Application.Handlers.Domains
{
    public class CreateDomainCommand : IRequest<CreateDomainResponse>
    {
        public Guid Id { get; private set; }

        public string? DNS;
        public string? OwnerName;
        public DateTime CreatedAt;

        public CreateDomainCommand() { 
            Id = Guid.NewGuid();
        }

        public DomainEntity GetEntity()
        {
            return new DomainEntity(this.DNS, this.OwnerName, this.CreatedAt);
        }
    }
}