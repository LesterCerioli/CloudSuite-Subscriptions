using CloudSuite.Modules.Application.Handlers.Users;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface IUserAppService
    {
        Task<UserViewModel> GetByUsername(string username);

        Task<UserViewModel> GetByCpf(Cpf cpf);

        Task<UserViewModel> GetByProfile(string profile);

        Task Save(CreateUserCommand commandcreate);
    }
}
