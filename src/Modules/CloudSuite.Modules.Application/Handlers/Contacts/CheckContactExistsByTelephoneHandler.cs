using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Application.Validation.Contacts;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Contacts
{
    public class CheckContactExistsByTelephoneHandler : IRequestHandler<CheckContactExistsByTelephoneRequest, CheckContactExistsByTelephoneResponse>
    {
        private IContactRepository _repositoryContact;
        private readonly ILogger<CheckContactExistsByNameHandler> _logger;

        public CheckContactExistsByTelephoneHandler(IContactRepository repositoryContact, ILogger<CheckContactExistsByNameHandler> logger)
        {
            _repositoryContact = repositoryContact;
            _logger = logger;
        }

        public async Task<CheckContactExistsByTelephoneResponse> Handle(CheckContactExistsByTelephoneRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckContactExistsByTelephoneRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckContactExistsByTelephoneRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var name = await _repositoryContact.GetByTelephone(new Telephone(request.Telephone));

                    if (name != null)
                        return await Task.FromResult(new CheckContactExistsByTelephoneResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckContactExistsByTelephoneResponse(request.Id, "The request could not be processed."));
                }
            }
            return await Task.FromResult(new CheckContactExistsByTelephoneResponse(request.Id, false, validationResult));
        }
    }
}
