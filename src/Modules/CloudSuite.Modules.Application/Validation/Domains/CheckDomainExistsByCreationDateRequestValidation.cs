using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Domains
{
    public class CheckDomainExistsByCreationDateRequestValidation : AbstractValidator<CheckDomainExistsByCreationDateRequest>
    {
        public CheckDomainExistsByCreationDateRequestValidation()
        {
            RuleFor(a => a.CreatedOn)
                .NotEmpty()
                .WithMessage("O campo CreatedOn não pode ser nulo")
                .NotNull()
                .WithMessage("O campo CreatedOn não pode ser nulo.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo CreatedOn deve ser uma data no passado ou presente.");
        }
    }
}
