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
            if (await ExistUserWithSameEmail(user.Email)) 
                return null;
                
            user.Password = SecurityUtils.EncryptPassword(user.Password);
            var newUser = await _userRepository.CreateAsync(user);
            return newUser;
        }

        public Task<User> DeleteAsync(Guid Id)
        {
            var deletedUser = _userRepository.DeleteAsync(Id);
            return deletedUser;
        }

        public Task<IEnumerable<User>> ReadAllAsync()
        {
            return _userRepository.ReadAll();
        }

        public Task<User> ReadOneAsync(Guid Id)
        {
            return _userRepository.ReadOneAsync(Id);
        }

        public async Task<User> ReadOneBy(Expression<Func<User, bool>> expression)
        {
            return await _userRepository.ReadOneBy(expression);
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotSupportedException();
        }
        private async Task<bool> ExistUserWithSameEmail(string email)
        {
            var user =  await _userRepository.ReadOneBy(x => x.Email == email);
            return user != null;
        }
    }
}
