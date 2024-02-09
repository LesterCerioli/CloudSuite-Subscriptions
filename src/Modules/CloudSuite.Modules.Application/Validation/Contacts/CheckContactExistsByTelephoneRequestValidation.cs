using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CheckContactExistsByTelephoneRequestValidation : AbstractValidator<CheckContactExistsByTelephoneRequest>
    {
        public CheckContactExistsByTelephoneRequestValidation()
        {
            RuleFor(a => a.Telephone)
            .NotEmpty()
            .WithMessage("Telephone field is required.")
            .Matches(new Regex(@"^\(\d{2}\)\s\d{5}-\d{4}$"))
            .WithMessage("The Telephone field must be in the format (xx) xxxxx-xxxx.");
        }
    }
}
