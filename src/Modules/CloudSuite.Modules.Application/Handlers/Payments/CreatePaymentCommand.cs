using CloudSuite.Modules.Application.Core;
using CloudSuite.Modules.Application.Handlers.Payments.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using PaymentEntity = CloudSuite.Modules.Domain.Models.Payment;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CreatePaymentCommand: IRequest<CreatePaymentResponse>
    {
        public Guid Id { get; private set; }
        public string? Number { get; set; }
        public DateTime? PaidTime {  get; set; }
        public DateTime? ExpireTime {  get; set; }
        public decimal Total {  get; set; }
        public decimal TotalPaid {  get; set; }
        public string? Payer { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }

        public CreatePaymentCommand()
        {
            Id = Guid.NewGuid();
        }

        public PaymentEntity GetEntity()
        {
            return new PaymentEntity(
                this.Number,
                this.PaidTime,
                this.ExpireTime,
                this.Total,
                this.TotalPaid,
                this.Payer,
                this.Cnpj,
                new Email(this.Email)
                );
        }


    }
}