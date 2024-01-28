using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Domains.Requests
{
    public class CheckDomainExistsByCreationDateRequest : IRequest<CheckDomainExistsByCreationDateResponse>
    {
        public Guid Id {  get; private set; }
        public DateTimeOffset CreatedOn {  get; set; }

        public CheckDomainExistsByCreationDateRequest(DateTimeOffset createdOn)
        {
            Id = Guid.NewGuid();
            CreatedOn = createdOn;
        }
    }
}
