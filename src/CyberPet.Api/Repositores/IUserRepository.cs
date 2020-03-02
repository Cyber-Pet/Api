using CyberPet.Api.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositores
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ReadAllAsync();
        Task<User> ReadOneAsync(ObjectId id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(ObjectId id);
    }
}
