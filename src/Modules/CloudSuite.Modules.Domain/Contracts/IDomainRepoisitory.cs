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

    public class DomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DomainEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class DomainRepository : IDomainRepository
    {
        private List<DomainEntity> domainEntities;

        public DomainRepository()
        {
            domainEntities = new List<DomainEntity>();
        }

        public DomainEntity GetDomainEntityById(int id)
        {
            return domainEntities.Find(entity => entity.Id == id);
        }

        public IEnumerable<DomainEntity> GetAllDomainEntities()
        {
            return domainEntities;
        }

        public void AddDomainEntity(DomainEntity entity)
        {
            domainEntities.Add(entity);
        }

        public void UpdateDomainEntity(DomainEntity entity)
        {
            var index = domainEntities.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                domainEntities[index] = entity;
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {entity.Id} not found");
            }
        }

        public void RemoveDomainEntity(int id)
        {
            var entityToRemove = domainEntities.Find(entity => entity.Id == id);
            if (entityToRemove != null)
            {
                domainEntities.Remove(entityToRemove);
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found");
            }
        }
    }
}
