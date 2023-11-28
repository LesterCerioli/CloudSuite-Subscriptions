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

        public Payment(string? number, DateTime? paidDate, DateTime? expireDate, Cnpj cnpj, decimal? total, decimal? totalPaid, string? payer, string? cnpj, string? email)
        {
            Number = number;
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Cnpj = cnpj(cnpj);
            Email = email(email);
        }
        
    }
}