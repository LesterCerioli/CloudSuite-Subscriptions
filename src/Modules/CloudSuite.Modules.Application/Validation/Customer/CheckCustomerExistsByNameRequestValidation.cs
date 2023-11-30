using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Customer
{
    public class CheckCustomerExistsByNameRequestValidation : AbstractValidator<CheckCustomerExistsByNameRequest>
    {
        public CheckCustomerExistsByNameRequestValidation()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .WithMessage("O campo Name deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Name deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo Name não pode ser nulo.");
        }
    }
}
