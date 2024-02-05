using CloudSuite.Modules.Application.Handlers.Contacts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CreateContactCommandValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidation()
        {
            RuleFor(a => a.Name)
           .NotEmpty()
           .WithMessage("O campo SocialName é obrigatório.")
           .Length(1, 100)
           .WithMessage("O campo SocialName deve ter entre 1 e 100 caracteres.")
           .Matches(@"^[a-zA-Z\s]*$")
           .WithMessage("O campo SocialName deve conter apenas letras e espaços.")
           .NotNull()
           .WithMessage("O campo SocialName não pode ser nulo.");

            RuleFor(a => a.Number)
            .NotEmpty()
            .WithMessage("Field is required")
            .NotNull()
            .WithMessage("The field cannot be null.");

            RuleFor(a => a.Email)
            .NotEmpty()
            .WithMessage("Email field is required.")
            .Length(10, 80)
            .WithMessage("The Email field must be between 1 and 450 characters.")
            .EmailAddress()
            .WithMessage("The Email field must be a valid email address.");
        }
    }
}
