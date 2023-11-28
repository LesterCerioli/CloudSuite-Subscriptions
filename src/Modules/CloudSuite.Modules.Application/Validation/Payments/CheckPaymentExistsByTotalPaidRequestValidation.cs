using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByTotalPaidRequestValidation : AbstractValidator<CheckPaymentExistsByTotalPaidRequest>
    {
        public CheckPaymentExistsByTotalPaidRequestValidation()
        {
            RuleFor(a => a.TotalPaid)
                .GreaterThanOrEqualTo(0)
                .When(a => a.TotalPaid.HasValue)
                .WithMessage("O valor total pago deve ser maior ou igual a 0.");
        }
    }
}