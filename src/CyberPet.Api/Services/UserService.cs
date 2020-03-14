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

        public Task<User> GetByIdAsync(Guid Id)
        {
            return _userRepository.GetByIdAsync(Id);
        }

        public async Task<User> ReadOneBy(Expression<Func<User, bool>> expression)
        {
            return await _userRepository.ReadOneBy(expression);
        }

        public Task<int> UpdateAsync(User user)
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
