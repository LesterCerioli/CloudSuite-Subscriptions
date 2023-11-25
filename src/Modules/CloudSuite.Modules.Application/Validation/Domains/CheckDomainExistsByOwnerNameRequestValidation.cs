using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Domains
{
    public class CheckDomainExistsByOwnerNameRequestValidation : AbstractValidator<CheckDomainExistsByOwnerNameRequest>
    {
        public CheckDomainExistsByOwnerNameRequestValidation()
        {
            RuleFor(a => a.OwnerName)
               .NotEmpty()
               .WithMessage("O campo OwnerName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo OwnerName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo OwnerName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo OwnerName não pode ser nulo.");
        }
    }
}
