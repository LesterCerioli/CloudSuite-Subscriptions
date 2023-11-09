using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Customers.Requests
{
    public class CheckCustomerExistsByCnpjRequest : IRequest<CheckCustomerExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }
        
        public Cnpj Cnpj { get; set; }
        
        public CheckCustomerExistsByCnpjRequest(Cnpj cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}

