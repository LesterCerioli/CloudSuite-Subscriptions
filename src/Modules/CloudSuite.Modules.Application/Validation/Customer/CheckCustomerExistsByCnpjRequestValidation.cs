using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Customer
{
    public class CheckCustomerExistsByCnpjRequestValidation: AbstractValidator<CheckCustomerExistsByCnpjRequest>
    {
        public CheckCustomerExistsByCnpjRequestValidation() {
            RuleFor(a => a.Cnpj).Custom((numDoc, context) => {
                try
                {
                    new Cnpj(numDoc);
                }
                catch (Exception ex)
                {
                    context.AddFailure(ex.Message);
                }
            });

            RuleFor(a => a.Cnpj)
                .NotEmpty()
                .WithMessage("O campo de Cnpj deve ser preenchido");
        }

    }
}
