using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Payments.Requests
{
    public class CheckPaymentExistsByCnpjRequest : IRequest<CheckPaymentExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }

        public string Cnpj { get; private set; }

        public CheckPaymentExistsByCnpjRequest(string? cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}