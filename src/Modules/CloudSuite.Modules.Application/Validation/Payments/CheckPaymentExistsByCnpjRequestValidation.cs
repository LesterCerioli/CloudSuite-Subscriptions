using CloudSuite.Modules.Application.Handlers.Payments.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
using FluentValidation;
using System.Data;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CheckPaymentExistsByCnpjRequestValidation : AbstractValidator<CheckPaymentExistsByCnpjRequest>
    {
        public CheckPaymentExistsByCnpjRequestValidation()
        {
            RuleFor(a => a.Cnpj).Custom((numDoc, context) =>
            {
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
                .WithMessage("O Cnpj deve ser preenchido.");

        }
    }
}