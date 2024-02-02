using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Subscription
{
    public class CheckSubscriptionExistsByCreateDateAndExpireDateValidation : AbstractValidator<CheckSubscriptionExistsByCreateDateAndExpireDateRequest>
    {
        public CheckSubscriptionExistsByCreateDateAndExpireDateValidation()
        {
            RuleFor(a => a.CreateDate)
                .NotEmpty()
                .WithMessage("O campo é obrigatório")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo CreateDate deve ser uma data e hora no passado ou presente");

            RuleFor(a => a.ExpirteDate)
                .NotEmpty()
                .WithMessage("O campo é obrigatório")
                .GreaterThan( a => a.CreateDate)
                .WithMessage("O Campo ExpireDate deve ser uma data e hora posterior a CreateDate");
        }
    }
}
