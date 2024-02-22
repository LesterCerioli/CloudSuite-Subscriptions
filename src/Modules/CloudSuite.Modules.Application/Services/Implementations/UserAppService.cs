using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Users;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Contracts;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public UserAppService(
            IUserRepository userRepository,
            IMapper mapper,
            IMediatorHandler mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        
        
        public async Task<UserViewModel> GetByCpf(Cpf cpf)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetByCpf(cpf));
        }

        public async Task<UserViewModel> GetByProfile(string profile)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetByProfile(profile));
        }

        public async Task<UserViewModel> GetByUsername(string username)
        {
            return _mapper.Map<UserViewModel>(await _userRepository.GetByUsername(username));
        }

        public async Task Save(CreateUserCommand commandcreate)
        {
            await _userRepository.Add(commandcreate.GetEntity());
        }
    }
}
