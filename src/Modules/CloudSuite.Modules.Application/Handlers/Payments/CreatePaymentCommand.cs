using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.Handlers.Payments
{
    public class CreatePaymentCommand: IRequest<CreatePaymentResponse>
    {
        public string? Number { get; set; }
        public DateTime? PaidTime {  get; set; }
        public DateTime? ExpireTime {  get; set; }
        public decimal? Total {  get; set; }
        public decimal? TotalPaid {  get; set; }
        public string? Payer { get; set; }
        public Cnpj cnpj { get; private set; }
        public Email email { get; private set; }

        public PaymentEntity GetEntity()
        {
            return new PaymentEntity(
                this.Number,
                this.PaidTime,
                this.ExpireTime,
                this.Total,
                this.TotalPaid,
                this.Payer,
                this.cnpj,
                this.email
                );
        }


    }
}