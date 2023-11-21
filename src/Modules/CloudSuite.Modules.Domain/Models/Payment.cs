using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Payment : Entity, IAggregateRoot
    {
        public string? Number { get; private set; }
        
        public DateTime? PaidDate { get; private set; }
        
        public DateTime? ExpireDate { get; private set; }
        
        public decimal? Total { get; private set; }
        
        public decimal? TotalPaid { get; private set; }
        
        public string? Payer { get; private set; }
        
        public Cnpj Cnpj { get; private set; }
        
        public Email Email { get; private set; }

        public Payment(string? payment, DateTime? paidDate, DateTime? expireDate, decimal? total, decimal? totalPaid, string? payer, string? cnpj, string? email)
        {
            this.Number = Number;
            this.PaidDate = paidDate;
            this.ExpireDate = expireDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Payer = payer;
            this.Cnpj = new Cnpj(cnpj);
            this.Email = new Email(email);
        }
        
    }
}