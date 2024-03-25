using CloudSuite.Subscriptions.Domain.Models/
using CloudSuite.Commons.ValueObjects;

namespace CloudSuite.Subscriptions.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task<Company> GetBySocialName(string socialName);

        Task<Company> GetByCnpj(Cnpj cnpj);

        Task<Company> GetByFantasyName(string fantasyName);
        
        Task<IEnumerable<Company>> GetList();

        Task Add(Company company);

        void Update(Company company);

        void Remove(Company company);
    }
}