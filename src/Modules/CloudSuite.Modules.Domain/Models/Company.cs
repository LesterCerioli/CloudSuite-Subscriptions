using System.Reflection.PortableExecutable;
using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Company : Entity, IAggregateRoot
    {
        public Company(Cnpj cnpj, string? socialName, string? fantasyName)
        {
            Cnpj = cnpj;
            SocialName = socialName;
            FantasyName = fantasyName;
        }

        public Cnpj Cnpj { get; private set; }

        public string? SocialName { get; private set; }

        public string? FantasyName { get; private set; }

        public DateTime FundationDate { get; private set; }
        
    }
}