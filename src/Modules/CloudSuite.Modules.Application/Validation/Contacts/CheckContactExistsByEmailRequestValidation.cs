using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CheckContactExistsByEmailRequestValidation : AbstractValidator<CheckContactExistsByEmailRequest>
    {
        public CheckContactExistsByEmailRequestValidation()
        {
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
