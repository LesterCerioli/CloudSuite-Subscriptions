using CloudSuite.Modules.Application.Handlers.Contacts;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CreateContactCommandValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidation()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("The Name field is required.")
            .Length(1, 100)
            .WithMessage("The SocialName field must be between 1 and 100 characters.")
            .Matches(@"^[a-zA-Z\s]*$")
            .WithMessage("The SName field must contain only letters and spaces.")
            .NotNull()
            .WithMessage("The Name field cannot be null.");

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
