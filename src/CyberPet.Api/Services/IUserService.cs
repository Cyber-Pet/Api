using CyberPet.Api.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ReadAllAsync();
        Task<User> ReadOneAsync(ObjectId Id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(ObjectId Id);

    }
}
