using CloudSuite.Modules.Application.Handlers.Company.Requests;
using CloudSuite.Modules.Commons.Valueobjects;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Company
{
    public class CheckCompanyExistsByCnpjRequestValidation : AbstractValidator<CheckCompanyExistsByCnpjRequest>
    {
        public CheckCompanyExistsByCnpjRequestValidation()
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