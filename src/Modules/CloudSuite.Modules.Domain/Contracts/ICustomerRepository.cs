using System.Security.AccessControl;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByCnpj(Cnpj cnpj);
    }
}
