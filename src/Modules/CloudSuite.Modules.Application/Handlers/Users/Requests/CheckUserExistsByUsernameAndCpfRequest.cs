using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Users.Requests
{
    public class CheckUserExistsByUsernameAndCpfRequest : IRequest<CheckUserExistsByUsernameAndCpfRequest>
    {
        public Guid Id { get; private set; }

        public bool Exists { get; set; }

        public string? Cpf { get; set; }

        public string? Username { get; set; }

        

        public CheckUserExistsByUsernameAndCpfRequest(bool exists, string username, string cpf)
        {
            Exists = exists;
            Id = Guid.NewGuid();
            Username = username;
            Cpf = cpf;

        }
    }
}
