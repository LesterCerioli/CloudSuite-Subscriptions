using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Domain.Models
{
	public interface IDomainRepository
	{
		Task<DomainEntidade> GetByDns(string dns);

		Task<DomainEntidade> GetByOwnerName(string ownerName);

		Task<DomainEntidade> GetByCreationDate(DateTimeOffset creationDate);

		Task<IEnumerable<DomainEntidade>> GetList();

		Task Add(DomainEntidade company);

		void UpdateDomainEntity(DomainEntidade domain);

		void RemoveDomainEntity(DomainEntidade domain);
		
	}


}

