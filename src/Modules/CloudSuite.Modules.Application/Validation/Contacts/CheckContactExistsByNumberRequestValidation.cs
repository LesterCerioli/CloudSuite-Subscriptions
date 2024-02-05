using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CheckContactExistsByNumberRequestValidation : AbstractValidator<CheckContactExistsByNumberRequest>
    {
        public CheckContactExistsByNumberRequestValidation()
        {
            RuleFor(a => a.Number)
            .NotEmpty()
            .WithMessage("Field is required")
            .NotNull()
            .WithMessage("The field cannot be null.");
        }
    }
}
