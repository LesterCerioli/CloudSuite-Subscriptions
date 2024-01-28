using CloudSuite.Modules.Application.Handlers.Domains.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Domains.Requests
{
    public class CheckDomainExistsByDnsRequest : IRequest<CheckDomainExistsByDnsResponse>
    {
        public Guid Id {  get; private set; }
        public string?  DNS { get; set; }

        public CheckDomainExistsByDnsRequest(string dns)
        {
            Id = Guid.NewGuid();
            DNS = dns;
        }
    }
}