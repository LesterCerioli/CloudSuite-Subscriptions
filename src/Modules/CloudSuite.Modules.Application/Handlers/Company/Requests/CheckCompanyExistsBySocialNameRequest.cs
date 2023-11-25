using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Company.Requests
{
    public class CheckCompanyExistsBySocialNameRequest : IRequest<CheckCompanyExistsBySocialNameResponse>
    {
        public Guid Id { get; private set; }

        public string SocialName { get; set; }

        public CheckCompanyExistsBySocialNameRequest(string socialName)
        {
            Id = Guid.NewGuid();
            SocialName = socialName;
        }
    }
}