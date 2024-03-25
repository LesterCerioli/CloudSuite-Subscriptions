using NetDevPack.Domain;

namespace CloudSuite.Subscriptions.Domain.Models
{
    public class DomainEntidade : Entity, IAggregateRoot
    {
        public DomainEntidade(string? dNS, string? ownerName, DateTimeOffset? creationDate)
        {
            DNS = dNS;
            OwnerName = ownerName;
            CreationDate = DateTime.Now;
        }

        public string? DNS { get; private set; }

		public string? OwnerName { get; private set; }

		public DateTimeOffset? CreationDate { get; private set; }
    }
}