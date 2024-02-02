using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Subscription
{
    public class CheckSubscriptionExistsByActiveRequestValidation : AbstractValidator<CheckSubscriptionExistsByActiveRequest>
    {
        public CheckSubscriptionExistsByActiveRequestValidation()
        {
            RuleFor(a => a.Active)
              .NotNull()
              .WithMessage("O campo Active não pode ser nulo.");
        }
    }
}
