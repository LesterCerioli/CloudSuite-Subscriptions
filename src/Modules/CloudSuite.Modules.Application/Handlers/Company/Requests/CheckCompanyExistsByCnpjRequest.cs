using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Company.Requests
{
    public class CheckCompanyExistsByCnpjRequest : IRequest<CheckCompanyExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }

        public string Cnpj { get; set; }

        public CheckCompanyExistsByCnpjRequest(string? cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}