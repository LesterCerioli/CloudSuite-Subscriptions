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
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.FantasyName)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

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
