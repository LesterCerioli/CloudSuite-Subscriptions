using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Subscription
{
    public class CheckSubscriptionExistsBySubscriptionNumberValidation : AbstractValidator<CheckSubscriptionExistsBySubscriptionNumberRequest>
    {

        public CheckSubscriptionExistsBySubscriptionNumberValidation() {
            RuleFor(a => a.SubscriptionNumber)
            .NotEmpty()
            .WithMessage("O campo SubscriptionNumber é obrigatório")
            .NotNull()
            .WithMessage("O campo SubscriptionNumber não pode ser nulo");
        }
    }
}
