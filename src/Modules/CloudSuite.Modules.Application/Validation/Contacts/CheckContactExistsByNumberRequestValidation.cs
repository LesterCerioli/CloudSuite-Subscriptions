using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validation.Contacts
{
    public class CheckContactExistsByNumberRequestValidation : AbstractValidator<CheckContactExistsByNumberRequest>
    {
    }
}
