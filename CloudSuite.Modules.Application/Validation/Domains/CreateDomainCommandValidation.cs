using CloudSuite.Modules.Application.Handlers.Domains;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Domains
{
    public class CreateDomainCommandValidation : AbstractValidator<CreateDomainCommand>
    {
        public CreateDomainCommandValidation() {

            RuleFor(a => a.OwnerName)
               .NotEmpty()
               .WithMessage("O campo OwnerName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo OwnerName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo OwnerName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo OwnerName não pode ser nulo.");

            RuleFor(a => a.DNS)
               .NotEmpty()
               .WithMessage("O campo DNS é obrigatório.")
               .Length(7, 15)
               .WithMessage("O campo DNS deve ter entre 7 e 15 caracteres.")
               .NotNull()
               .WithMessage("O campo DNS não pode ser nulo.");

            RuleFor(a => a.CreatedAt)
                .NotEmpty()
                .WithMessage("O campo createdAt não pode ser nulo")
                .NotNull()
                .WithMessage("O campo DNS não pode ser nulo.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo createdAt deve ser uma data e hora no passado ou presente.");

        }
    }
}
