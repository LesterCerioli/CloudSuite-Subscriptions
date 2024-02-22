using CloudSuite.Modules.Application.Handlers.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Users
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
    }
}
