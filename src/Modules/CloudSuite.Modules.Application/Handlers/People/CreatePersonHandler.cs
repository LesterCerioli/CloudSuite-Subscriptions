using CloudSuite.Modules.Application.Handlers.People.Responses;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.People
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, CreatePersonResponse>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<CreatePersonHandler> _logger;

        public CreatePersonHandler(IPersonRepository personRepository, ILogger<CreatePersonHandler> logger)
        {
            _personRepository = personRepository;
            _logger = logger;

        }


        public async Task<CreatePersonResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
