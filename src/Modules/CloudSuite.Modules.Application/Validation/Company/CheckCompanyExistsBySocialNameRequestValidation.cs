using CloudSuite.Modules.Application.Handlers.Company.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckCompanyExistsBySocialNameRequestValidation : AbstractValidator<CheckCompanyExistsBySocialNameRequest>
    {
        public CheckCompanyExistsBySocialNameRequestValidation()
        {
            RuleFor(a => a.SocialName)
                .NotEmpty()
                .WithMessage("O campo SocialName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo SocialName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo SocialName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo SocialName não pode ser nulo.");
        }
    }
}