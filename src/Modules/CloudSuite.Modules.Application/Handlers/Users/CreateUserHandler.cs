using CloudSuite.Modules.Application.Handlers.Users.Responses;

using CloudSuite.Modules.Application.Validation.Users;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;

        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateUserCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateUserCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var existingUser = await _userRepository.GetByUsername(command.Username);
                    if (existingUser != null)
                    {
                        return await Task.FromResult(new CreateUserResponse(command.Id, "Nome de usuário já existe."));
                    }

                    var userProfile = await _userRepository.GetByProfile(command.Profile);

                    if (userProfile != null) 
                    {
                        return await Task.FromResult(new CreateUserResponse(command.Id, "Perfil já cadastrado"));
                    }

                    
                    return await Task.FromResult(new CreateUserResponse(command.Id, "Usuário criado com sucesso."));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao criar usuário");
                    return await Task.FromResult(new CreateUserResponse(command.Id, "Não foi possível criar o usuário."));
                }
            }
            return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
        }
    }
}
