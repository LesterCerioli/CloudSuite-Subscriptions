using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByPayerRequestValidation : AbstractValidator<CheckPaymentExistsByPayerRequest>
    {
        public CheckPaymentExistsByPayerRequestValidation()
        {
            RuleFor(a => a.Payer)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");
        }
    }
}
