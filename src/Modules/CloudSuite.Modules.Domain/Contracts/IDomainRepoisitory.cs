namespace CloudSuite.Modules.Domain

public interface IDomainRepository
{
    Task<Domian> GetByDns(string dns);

    Task<Domaian> GetByOwnerName(string ownerName);

    Task<Domian> GetByCreationDate(DateTimeOffset creationDate);

    void UpdateDomainEntity(DomainEntity entity);

    void RemoveDomainEntity(int id);
}





