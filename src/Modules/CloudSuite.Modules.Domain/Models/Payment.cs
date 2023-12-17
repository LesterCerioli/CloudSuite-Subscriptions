using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Payment : Entity, IAggregateRoot
    {
		public Payment(string? number, DateTime? paidDate, DateTime? expireDate, decimal? total, decimal? totalPaid, string? payer, Cnpj cnpj, Email email)
		{
			Number = number;
			PaidDate = paidDate;
            ExpireDate = DateTime.Now;
			Total = total;
			TotalPaid = totalPaid;
			Payer = payer;
			Cnpj = cnpj;
			Email = email;
		}

		public string? Number { get; private set; }
        
        public DateTime? PaidDate { get; private set; }
        
        public DateTime? ExpireDate { get; private set; }
        
        public decimal? Total { get; private set; }
        
        public decimal? TotalPaid { get; private set; }
        
        public string? Payer { get; private set; }
        
        public Cnpj Cnpj { get; private set; }
        
        public Email Email { get; private set; }

        
        
    }
}