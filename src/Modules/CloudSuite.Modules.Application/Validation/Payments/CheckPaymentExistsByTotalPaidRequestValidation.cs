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
                .WithMessage("O campo não pode estar vazio.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor total pago deve ser maior ou igual a 0.");
        }
    }
}