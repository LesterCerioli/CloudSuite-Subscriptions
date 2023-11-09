using CloudSuite.Modules.Domain.Models;
using Sytem.Collection.Generic;
using System.Theading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task<Company> GetBySocialName(string socialName);

        Task<Company> GetByCnpj(Cnpj cnpj);

        Task<Company> GetByFantasyName(string fantasyName);

        Task<Company> GetByCorporateReason(string corporateReason);

        Task<Company> getByContact(string contact);

        Task<Company> getByTelephone(Telephone telephone);

        Task<Company> getByCell(Cell cell);

        Task<Company> getByDateOfBirth(DateOfBirth dateOfBirth);

        Task<IEnumerable<Company>> GetList();

        Task Add(Company company);

        void Update(Company company);

        void Remove(Company company);
    }
}