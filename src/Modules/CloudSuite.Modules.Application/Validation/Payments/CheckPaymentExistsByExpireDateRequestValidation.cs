using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;


namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByExpireDateRequestValidation : AbstractValidator<CheckPaymentExistsByExpireDateRequest>
    {
        public CheckPaymentExistsByExpireDateRequestValidation()
        {
            RuleFor(a => a.ExpireDate)
               .GreaterThanOrEqualTo(DateTime.Now)
               .WithMessage("O campo ExpireDate deve ser uma data futura ou presente.");
        }
    }
}
