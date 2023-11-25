using CloudSuite.Modules.Application.Handlers.Subscriptions;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Subscription
{
    public class CreateSubscriptionCommandValidation : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidation() {

            RuleFor(a => a.SubscriptionNumber)
            .NotEmpty()
            .WithMessage("O campo SubscriptionNumber é obrigatório")
            .NotNull()
            .WithMessage("O campo SubscriptionNumber não pode ser nulo");

            RuleFor(a => a.CreateDate)
            .NotEmpty()
            .WithMessage("O campo é obrigatório")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("O campo CreateDate deve ser uma data e hora no passado ou presente");

            RuleFor(a => a.LastUpdateDate)
             .GreaterThanOrEqualTo(a => a.CreateDate)
             .WithMessage("O campo LatestUpdatedOn deve ser uma data no mesmo momento ou depois de CreatedOn.")
             .LessThanOrEqualTo(DateTime.Now)
             .WithMessage("O campo LatestUpdatedOn deve ser uma data no passado ou presente.");

            RuleFor(a => a.ExpirteDate)
            .NotEmpty()
            .WithMessage("O campo é obrigatório")
            .GreaterThan(a => a.CreateDate)
            .WithMessage("O Campo ExpireDate deve ser uma data e hora posterior a CreateDate");
        }
    }
}
