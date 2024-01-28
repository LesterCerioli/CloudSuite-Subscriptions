using CloudSuite.Modules.Application.Handlers.Payments;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validation.Payments
{
    public class CreatePaymentCommandValidation : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo.")
                .EmailAddress()
                .WithMessage("Formato incorreto.");

            RuleFor(a => a.Cnpj)
                .Must(cnpj => IsValid(cnpj))
                .WithMessage("O campo cnpj é inválido");

            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.PaidTime)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo ExpireTime deve ser uma data no futuro ou presente.");

            RuleFor(a => a.ExpireTime)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo ExpireTime deve ser uma data no futuro ou presente.");

            RuleFor(a => a.Total)
                .NotEmpty()
                .WithMessage("O campo é obrigatório.")
                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(a => a.TotalPaid)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor total deve ser maior ou igual a 0.");

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

        private bool IsValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Remove non-digit characters
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            // CNPJ must have 14 digits
            if (cnpj.Length != 14)
                return false;

            // Check for repeated digits or invalid checksum
            if (IsRepeatedDigits(cnpj) || !IsValidChecksum(cnpj))
                return false;

            return true;
        }

        private bool IsRepeatedDigits(string cnpjNumber)
        {
            return cnpjNumber == new string(cnpjNumber[0], 14);
        }

        // Private method to validate the CNPJ checksum
        private bool IsValidChecksum(string cnpjNumber)
        {
            var sum = 0;
            var multiplier = 5;

            // Calculate the first checksum digit
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 6;

            // Calculate the second checksum digit
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Compare the calculated checksum digits with the provided ones
            return (int.Parse(cnpjNumber[12].ToString()) == digit1) && (int.Parse(cnpjNumber[13].ToString()) == digit2);
        }
    }
}
