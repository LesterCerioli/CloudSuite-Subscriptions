using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Application.Validation.Contacts;
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
    public class CheckContactExistsByNumberHandler : IRequestHandler<CheckContactExistsByNumberRequest, CheckContactExistsByNumberResponse>
    {
        private IContactRepository _repositoryContact;
        private readonly ILogger<CheckContactExistsByNumberHandler> _logger;

        public CheckContactExistsByNumberHandler(IContactRepository repositoryContact, ILogger<CheckContactExistsByNumberHandler> logger)
        {
            _repositoryContact = repositoryContact;
            _logger = logger;
        }

        public async Task<CheckContactExistsByNumberResponse> Handle(CheckContactExistsByNumberRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckContactExistsByNumberRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckContactExistsByNumberRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var number = await _repositoryContact.GetByNumber(request.Number);

                    if (number != null)
                        return await Task.FromResult(new CheckContactExistsByNumberResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckContactExistsByNumberResponse(request.Id, "The request could not be processed."));
                }
            }
            return await Task.FromResult(new CheckContactExistsByNumberResponse(request.Id, false, validationResult));
        }
    }
}
