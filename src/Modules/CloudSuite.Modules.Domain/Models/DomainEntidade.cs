using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class DomainEntidade : Entity, IAggregateRoot
    {
        public DomainEntidade()
        {

        }
        
        public DomainEntidade(string? dNS, string ownerName, DateTimeOffset? creationDate)
        {
            DNS = dNS;
            OwnerName = ownerName;
            CreationDate = creationDate;
        }

        public string? DNS { get; private set; }

        public string OwnerName { get; private set; }
        
        public DateTimeOffset? CreationDate { get; private set; }
    }
}