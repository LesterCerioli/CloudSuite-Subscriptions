using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
		public Customer()
		{
		}

		public Customer(Name name, Cnpj cnpj, Email email, string? businessOwner, DateTimeOffset? createdOn,
            Company company)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
            BusinessOwner = businessOwner;
            CreatedOn = createdOn;
            Company = company;
            
        }

        public Customer(Name name, Cnpj cnpj, Email email, string? businessOwner, DateTimeOffset? createdOn)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
            BusinessOwner = businessOwner;
            CreatedOn = createdOn;
        }

        public Name Name { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Email Email { get; private set; }

        public string? BusinessOwner { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public Company Company { get; private set; }

        public Guid ComoanyId { get; private set; }

        public IList<Company> Companies { get; set; }
        
    }
}