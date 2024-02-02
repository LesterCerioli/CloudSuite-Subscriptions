using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Customer
{
    public class CheckCustomerExistsByEmailRequestValidation : AbstractValidator<CheckCustomerExistsByEmailRequest>
    {
        public CheckCustomerExistsByEmailRequestValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatório.")
                .Length(1, 80)
                .WithMessage("O campo Email deve ter entre 1 e 450 caracteres.")
                .EmailAddress()
                .WithMessage("O campo Email deve ser um endereço de email válido.");
        }
    }
}
