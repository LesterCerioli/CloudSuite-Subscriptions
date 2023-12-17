using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        public async Task Add(Domain company)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain> GetByCreationDate(DateTimeOffset creationDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain> GetByDns(string dns)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain> GetByOwnerName(string ownerName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain>> GetList()
        {
            throw new NotImplementedException();
        }

        public void RemoveDomainEntity(Domain domain)
        {
            throw new NotImplementedException();
        }

        public void UpdateDomainEntity(Domain domain)
        {
            throw new NotImplementedException();
        }
    }
}