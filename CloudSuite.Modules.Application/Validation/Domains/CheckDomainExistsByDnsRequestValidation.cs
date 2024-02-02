using CloudSuite.Modules.Application.Handlers.Domains.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Domains
{
    public class CheckDomainExistsByDnsRequestValidation: AbstractValidator<CheckDomainExistsByDnsRequest>
    {
        public CheckDomainExistsByDnsRequestValidation() {
            RuleFor(a => a.DNS)
               .NotEmpty()
               .WithMessage("O campo DNS é obrigatório.")
               .Length(7, 15)
               .WithMessage("O campo DNS deve ter entre 7 e 15 caracteres.")
               .NotNull()
               .WithMessage("O campo DNS não pode ser nulo.");
        }
    }
}
