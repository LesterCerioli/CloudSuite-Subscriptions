﻿using CloudSuite.Modules.Application.Handlers.Contacts.Requests;
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
        private IContactRepository _repositoryContact;
        private readonly ILogger<CheckContactExistsByNameHandler> _logger;

        public CheckContactExistsByNameHandler(IContactRepository repositoryContact, ILogger<CheckContactExistsByNameHandler> logger)
        {
            _repositoryContact = repositoryContact;
            _logger = logger;
        }

        public async Task<Responses.CheckContactExistsByNameResponse> Handle(Requests.CheckContactExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckContactExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckContactExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var name = await _repositoryContact.GetByName(new Name(request.Name));

                    if (name != null)
                        return await Task.FromResult(new Responses.CheckContactExistsByNameResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new Responses.CheckContactExistsByNameResponse(request.Id, "The request could not be processed."));
                }
            }
            return await Task.FromResult(new Responses.CheckContactExistsByNameResponse(request.Id, false, validationResult));
        }
    }
}