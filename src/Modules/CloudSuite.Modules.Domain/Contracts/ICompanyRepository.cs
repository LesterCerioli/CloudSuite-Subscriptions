using CloudSuite.Modules.Domain.Models;
using Sytem.Collection.Generic;
using System.Theading.Tasks;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Domain.Contracts
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