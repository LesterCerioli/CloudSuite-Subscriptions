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
    public class CheckContactExistsByNameHandler : IRequestHandler<CheckContactExistsByNameRequest, CheckContactExistsByNameResponse>
    {
        private IContactRepository _contactRepository;
        private readonly ILogger<CheckContactExistsByNameHandler> _logger;

        public CheckContactExistsByNameHandler(IContactRepository contactRepository, ILogger<CheckContactExistsByNameHandler> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        public async Task<CheckContactExistsByNameResponse> Handle(CheckContactExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckContactExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckContactExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var contactName = await _contactRepository.GetByName(new Name(request.Name));

                    if (contactName != null)
                        return await Task.FromResult(new CheckContactExistsByNameResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckContactExistsByNameResponse(request.Id, "The request could not be processed."));
                }
            }
            return await Task.FromResult(new CheckContactExistsByNameResponse(request.Id, false, validationResult));
        }
    }
}
