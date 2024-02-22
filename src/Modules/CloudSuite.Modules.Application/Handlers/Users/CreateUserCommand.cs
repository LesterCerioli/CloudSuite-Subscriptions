using CloudSuite.Modules.Application.Handlers.Users.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = CloudSuite.Modules.Domain.Models.User;

namespace CloudSuite.Modules.Application.Handlers.Users
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public Guid Id { get; private set; }

        public string? Username { get; set; }
                
        public string? Password { get; set; }
                
        public string? Profile { get; set; }

        public string? Cpf {get; set; }

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public UserEntity GetEntity()
        {
            return new UserEntity(
                this.Username,
                this.Password,
                this.Profile,
                this.Cpf);
        }
    }
}
