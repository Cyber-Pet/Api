using CyberPet.Api.Models;
using CyberPet.Api.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public Task<User> CreateAsync(User user)
        {
            throw new NotSupportedException();
        }

        public Task<User> DeleteAsync(Guid Id)
        {
            throw new NotSupportedException();
        }

        public Task<IEnumerable<User>> ReadAllAsync()
        {
            return _userRepository.ReadAll();
        }

        public Task<User> ReadOneAsync(Guid Id)
        {
            return _userRepository.ReadOneAsync(Id);
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotSupportedException();
        }
    }
}
