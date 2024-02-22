using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByCpf(Cpf cpf);

        Task<User> GetByUsername(string username);

        Task<User> GetByProfile(string profile);
        
        Task Add(User user);

        void Update(User user);

        void Remove(User user);
        Task GetByCpf(string? cpf);
    }
}
