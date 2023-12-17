using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Company.Requests
{
    public class CheckCompanyExistsByFantasyNameRequest : IRequest<CheckCompanyExistsByFantasyNameResponse>
    {
        public Guid Id { get; private set; }

        public string FantasyName { get; set; }

        public CheckCompanyExistsByFantasyNameRequest(string fantasyName)
        {
            Id = Guid.NewGuid();
            FantasyName = fantasyName;
        }

    }
}