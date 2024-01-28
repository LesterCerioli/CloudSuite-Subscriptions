using CloudSuite.Modules.Application.Handlers.People.Requests;
using CloudSuite.Modules.Application.Handlers.People.Responses;
using CloudSuite.Modules.Application.Handlers.Subscriptions;
using CloudSuite.Modules.Application.Handlers.Subscriptions.Responses;
using CloudSuite.Modules.Application.Validation.People;
using CloudSuite.Modules.Application.Validation.Subscription;
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

namespace CloudSuite.Modules.Application.Handlers.People
{
    public class CheckPersonExistsByNameHandler : IRequestHandler<CheckPersonExistsByNameRequest, CheckPersonExistsByNameResponse>
    {
        private IPersonRepository _personRepository;
        private readonly ILogger<CheckPersonExistsByNameHandler> _logger;

        public CheckPersonExistsByNameHandler(IPersonRepository personRepository, ILogger<CheckPersonExistsByNameHandler> logger)
        {
            _personRepository = personRepository;
            _logger = logger;
        }


        public async Task<CheckPersonExistsByNameResponse> Handle(CheckPersonExistsByNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckPersonExistsByNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckPersonExistsByNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var person = await _personRepository.GetByName(new Name(request.Name));                                                                         

                    if (person != null)
                    {
                        return await Task.FromResult(new CheckPersonExistsByNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckPersonExistsByNameResponse(request.Id, "N~ao foi possível processar a solicitação."));
                }
            }

            return await Task.FromResult(new CheckPersonExistsByNameResponse(request.Id, false, validationResult));
        }
    }
}
