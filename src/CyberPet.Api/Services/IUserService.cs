using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ReadAllAsync();
        Task<User> ReadOneAsync(Guid Id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(Guid id, User user);
        Task<User> DeleteAsync(Guid Id);

    }
}
