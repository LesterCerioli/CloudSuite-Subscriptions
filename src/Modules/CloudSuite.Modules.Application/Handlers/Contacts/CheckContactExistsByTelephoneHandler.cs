using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Application.Validation.Contacts;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Contacts
{
    public class CheckContactExistsByTelephoneHandler : IRequestHandler<CheckContactExistsByTelephoneRequest, CheckContactExistsByTelephoneResponse>
    {
        private IContactRepository _contactRepository;
        private readonly ILogger<CheckContactExistsByNameHandler> _logger;

        public CheckContactExistsByTelephoneHandler(IContactRepository contactRepository, ILogger<CheckContactExistsByNameHandler> logger)
        {
            _contactRepository = contactRepository;
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
                    var contactTelephone = await _contactRepository.GetByTelephone(new Telephone(request.Telephone));

                    if (contactTelephone != null)
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
