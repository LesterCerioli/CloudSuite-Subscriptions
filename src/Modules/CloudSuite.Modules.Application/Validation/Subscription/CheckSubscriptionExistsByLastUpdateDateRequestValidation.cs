using CloudSuite.Modules.Application.Handlers.Subscriptions.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Subscription
{
    public class CheckSubscriptionExistsByLastUpdateDateRequestValidation : AbstractValidator<CheckSubscriptionExistsByLastUpdateDateRequest>
    {
        public CheckSubscriptionExistsByLastUpdateDateRequestValidation()
        {
            RuleFor(a => a.LastUpdateDate)
               .LessThanOrEqualTo(DateTime.Now)
               .WithMessage("O campo LatestUpdatedOn deve ser uma data e hora no passado ou presente.");
        }
    }
}
