using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Customer
{
    public class CheckCustomerExistsByBusinessOwnerRequestValidation : AbstractValidator<CheckCustomerExistsByBusinessOwnerRequest>
    {
        public CheckCustomerExistsByBusinessOwnerRequestValidation()
        {
            RuleFor(a => a.BusinessOwner)
                .NotEmpty()
                .WithMessage("O campo BusinessOwner é obrigatório.")
                .WithMessage("O campo BusinessOwner deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo BusinessOwner deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo BusinessOwner não pode ser nulo.");
        }
    }
}
