using System;
using System.Collections.Generic;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IDomainRepository
    {
        DomainEntity GetDomainEntityById(int id);

        IEnumerable<DomainEntity> GetAllDomainEntities();

        void AddDomainEntity(DomainEntity entity);

        void UpdateDomainEntity(DomainEntity entity);

        void RemoveDomainEntity(int id);
    }

    

    
    
}
