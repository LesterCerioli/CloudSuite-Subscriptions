using CloudSuite.Modules.Application.Handlers.Payments;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CreatePaymentCommandValidation : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.")
                .EmailAddress()
                .WithMessage("Formato incorreto.");

            RuleFor(a => a.Cnpj)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.PaidTime)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo ExpireTime deve ser uma data no futuro ou presente.");

            RuleFor(a => a.ExpireTime)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo ExpireTime deve ser uma data no futuro ou presente.");

            RuleFor(a => a.Total)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.TotalPaid)
                .GreaterThanOrEqualTo(0)
                .When(a => a.TotalPaid.HasValue)
                .WithMessage("O valor total deve ser maior ou igual a 0.");

            RuleFor(a => a.Payer)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");
        }
    }
}
