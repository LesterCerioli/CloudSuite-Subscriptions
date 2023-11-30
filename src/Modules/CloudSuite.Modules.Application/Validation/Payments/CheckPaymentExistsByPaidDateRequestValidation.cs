using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByPaidDateRequestValidation : AbstractValidator<CheckPaymentExistsByPaidDateRequest>
    {
        public CheckPaymentExistsByPaidDateRequestValidation()
        {
            RuleFor(a => a.PaidDate)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo ExpireTime deve ser uma data e hora no passado ou presente.");
        }
    }
}
