using CloudSuite.Modules.Application.Handlers.Company;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CreateCompanyCommandValidation : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidation()
        {
            RuleFor(a => a.Cnpj)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.")
                .EmailAddress()
                .WithMessage("Formato incorreto.");

            RuleFor(a => a.SocialName)
                .NotEmpty()
                .WithMessage("O campo SocialName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo SocialName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo SocialName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo SocialName não pode ser nulo.");

            RuleFor(a => a.FantasyName)
                .NotEmpty()
                .WithMessage("O campo FantasyName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo FantasyName deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo FantasyName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo FantasyName não pode ser nulo.");

            RuleFor(a => a.FundationDate)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo FundationDate deve ser uma data no passado ou presente.");

        }
    }
}
