﻿using CloudSuite.Modules.Application.Handlers.Company;
using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Application.Validation.Contacts;
using CloudSuite.Modules.Application.Validation.Payments;
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
    public class CheckContactExistsByEmailHandler : IRequestHandler<CheckContactExistsByEmailRequest, CheckContactExistsByEmailResponse>
    {
        private IContactRepository _contactRepository;
        private readonly ILogger<CheckContactExistsByEmailHandler> _logger;

        public CheckContactExistsByEmailHandler(IContactRepository contactRepository, ILogger<CheckContactExistsByEmailHandler> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        public async Task<CheckContactExistsByEmailResponse> Handle(CheckContactExistsByEmailRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckContactExistsByEmailRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckContactExistsByEmailRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var contactEmail = await _contactRepository.GetByEmail(new Email(request.Email));

                    if (contactEmail != null)
                        return await Task.FromResult(new CheckContactExistsByEmailResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckContactExistsByEmailResponse(request.Id, "The request could not be processed."));
                }
            }
            return await Task.FromResult(new CheckContactExistsByEmailResponse(request.Id, false, validationResult));
        }
    }
}
