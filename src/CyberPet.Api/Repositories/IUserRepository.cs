using CyberPet.Api.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ReadAllAsync();
        Task<User> ReadOneAsync(Guid id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(Guid id);
    }
}
