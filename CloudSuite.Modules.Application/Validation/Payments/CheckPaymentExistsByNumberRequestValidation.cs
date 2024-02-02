using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByNumberRequestValidation : AbstractValidator<CheckPaymentExistsByNumberRequest>
    {
        public CheckPaymentExistsByNumberRequestValidation()
        {
            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("O campo é obrigatório")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.");
        }
    }
}