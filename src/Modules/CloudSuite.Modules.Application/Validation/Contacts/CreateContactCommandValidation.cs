using CloudSuite.Modules.Application.Handlers.Contacts;
using FluentValidation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CreateContactCommandValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidation()
        {
            RuleFor(a => a.Name)
           .NotEmpty()
           .WithMessage("Field is required")
           .NotNull()
           .WithMessage("The field cannot be null.")
           .Must(ValidateFullName)
           .WithMessage("The full name must be valid (accepts accents and does not contain numbers).");

            RuleFor(a => a.Telephone)
            .NotEmpty()
            .WithMessage("Telephone field is required.")
            .Matches(new Regex(@"^\(\d{2}\)\s\d{5}-\d{4}$"))
            .WithMessage("The Telephone field must be in the format (xx) xxxxx-xxxx.");

            RuleFor(a => a.Email)
            .NotEmpty()
            .WithMessage("Email field is required.")
            .Length(10, 80)
            .WithMessage("The Email field must be between 1 and 450 characters.")
            .EmailAddress()
            .WithMessage("The Email field must be a valid email address.");
        }


        private bool ValidateFullName(string name)
        {
            // Remove espaços extras e converte para título (primeira letra maiúscula)
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Trim());

            // Verifica se o nome completo contém apenas letras, espaços e acentuação
            if (!Regex.IsMatch(name, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$"))
            {
                return false;
            }

            // Divide o nome completo em partes (nome e sobrenome)
            string[] partesNome = name.Split(' ');

            // Verifica se há pelo menos duas partes (nome e sobrenome)
            if (partesNome.Length < 2)
            {
                return false;
            }

            // Verifica se cada parte não contém números
            foreach (string parte in partesNome)
            {
                if (Regex.IsMatch(parte, @"\d"))
                {
                    return false;
                }
            }

            // Se chegou até aqui, o nome completo é válido
            return true;
        }

    }
}
