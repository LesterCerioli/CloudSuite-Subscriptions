using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByCnpjRequest: IRequest<CheckCustomerExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }
        public string? Cnpj {  get; set; }

        public CheckCustomerExistsByCnpjRequest(string? cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}