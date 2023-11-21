using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Models
{
	public interface IDomainRepository
	{
		Task<Domain> GetByDns(string dns);

		Task<Domain> GetByOwnerName(string ownerName);

		Task<Domain> GetByCreationDate(DateTimeOffset creationDate);

		Task<IEnumerable<Domain>> GetList();

		Task Add(Domain company);

		void UpdateDomainEntity(Domain domain);

		void RemoveDomainEntity(Domain domain);
	}


}

