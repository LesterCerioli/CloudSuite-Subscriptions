using System.Reflection.PortableExecutable;
using CloudSuite.Commons.ValueObjects;
using NetDevPack.Domain;

namespace CloudSuite.Subscriptions.Domain.Models
{
    public class Company : Entity, IAggregateRoot
    {
        public Company()
		{
		}

		public Company(Cnpj cnpj, string? socialName, string? fantasyName, DateTime fundationDate)
        {
            Cnpj = cnpj;
            SocialName = socialName;
            FantasyName = fantasyName;
            FundationDate = fundationDate;
        }

        public Cnpj Cnpj { get; private set; }

        public string? SocialName { get; private set; }

        public string? FantasyName { get; private set; }

        public DateTime FundationDate { get; private set; }
    }

}