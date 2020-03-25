using CyberPet.Api.Models;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public async Task<User> CreateAsync(User user)
        {              
            user.Password = SecurityUtils.EncryptPassword(user.Password);
            await _userRepository.CreateAsync(user);
            return user;
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await _userRepository.DeleteAsync(Id); ;
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User> GetOneByIdAsync(Guid Id)
        {
            return _userRepository.GetOneByIdAsync(Id);
        }

        public async Task<User> ReadOneBy(Expression<Func<User, bool>> expression)
        {
            return await _userRepository.GetOneBy(expression);
        }

        public Task<int> UpdateAsync(User user)
        {
            throw new NotSupportedException();
        }

        Task<int> IUserService.CreateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
