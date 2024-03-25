using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Commons.ValueObjects;
using CloudSuite.Subscriptions.Domain.Models;

namespace CloudSuite.Subscriptions.Domain.Contracts
{
    public interface IDomainRepository
    {
        Task<DomainEntidade> GetByDns(string dns);

		Task<DomainEntidade> GetByOwnerName(string ownerName);

		Task<DomainEntidade> GetByCreationDate(DateTimeOffset creationDate);

		Task<IEnumerable<DomainEntidade>> GetList();

		Task Add(DomainEntidade domainEntidade);

		void Update(DomainEntidade domainEntidade);

		void Remove(DomainEntidade domainEntidade);
    }
}