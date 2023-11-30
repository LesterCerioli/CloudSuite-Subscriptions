
using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByEmailRequestValidation : AbstractValidator<CheckPaymentExistsByEmailRequest>
    {
        public CheckPaymentExistsByEmailRequestValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatório.")
                .Length(1, 80)
                .WithMessage("O campo Email deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Email deve ser um endereço de email válido.");
        }
    }
}
