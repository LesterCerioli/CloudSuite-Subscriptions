using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByTotalRequestValidation : AbstractValidator<CheckPaymentExistsByTotalRequest>
    {
        public CheckPaymentExistsByTotalRequestValidation()
        {
            RuleFor(a => a.Total)
                .GreaterThanOrEqualTo(0)
                .When(a => a.Total.HasValue)
                .WithMessage("O valor total deve ser maior ou igual a 0.");

        }
    }
}
