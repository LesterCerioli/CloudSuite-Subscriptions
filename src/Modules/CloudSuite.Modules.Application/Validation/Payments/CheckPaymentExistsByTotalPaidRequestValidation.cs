using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByTotalPaidRequestValidation : AbstractValidator<CheckPaymentExistsByTotalPaidRequest>
    {
        public CheckPaymentExistsByTotalPaidRequestValidation()
        {
            RuleFor(a => a.TotalPaid)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.")
                .LessThan(0)
                .WithMessage("O campo não pode ser negativo.");
        }
    }
}