using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Customer
{
    public class CheckCustomerExistsByCreatedOnRequestValidation : AbstractValidator<CheckCustomerExistsByCreatedOnRequest>
    {
        public CheckCustomerExistsByCreatedOnRequestValidation()
        {
            RuleFor(a => a.CreatedOn)
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("O campo CreatedOn deve ser uma data e hora no passado ou presente.");
        }
    }
}
