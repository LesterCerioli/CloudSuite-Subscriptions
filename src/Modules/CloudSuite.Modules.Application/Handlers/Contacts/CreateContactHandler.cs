using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.Contacts;
using CloudSuite.Modules.Application.Validation.Subscription;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
    {
        private IContactRepository _repositorioContact;
        private readonly ILogger<CreateContactHandler> _logger;

        public async Task<CreateContactResponse> Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateContactCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateContactCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var contactGetByNumber = await _repositorioContact.GetByNumber(command.Number);
                    var contactGetByEmail = await _repositorioContact.GetByEmail(command.Email);
                    

                    if (contactGetByNumber != null && contactGetByEmail != null)
                    {
                        return await Task.FromResult(new CreateContactResponse(command.Id, "contact already exists."));
                    }

                    await _repositorioContact.Add(command.GetEntity());
                    return await Task.FromResult(new CreateContactResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateContactResponse(command.Id, "The request could not be processed."));
                }
            }

            return await Task.FromResult(new CreateContactResponse(command.Id, validationResult));
        }
    }
}
