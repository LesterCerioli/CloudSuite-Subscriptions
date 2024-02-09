using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CheckContactExistsByNameRequestValidation : AbstractValidator<CheckContactExistsByNameRequest>
    {
        public CheckContactExistsByNameRequestValidation()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Field is required")
            .NotNull()
            .WithMessage("The field cannot be null.")
            .Must(ValidateFullName)
            .WithMessage("The full name must be valid (accepts accents and does not contain numbers).");
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
