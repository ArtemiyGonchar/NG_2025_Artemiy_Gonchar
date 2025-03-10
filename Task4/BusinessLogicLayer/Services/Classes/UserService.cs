using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<int> CreateAsync(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var userCreated = await _userRepository.CreateAsync(user);
            return userCreated;
        }
    }
}
