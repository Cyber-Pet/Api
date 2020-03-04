using CyberPet.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        public UserRepository(CyberPetDatabase database)
        {
            _users = database.Users;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public Task<User> DeleteAsync(ObjectId id)
        {

            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> ReadAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ReadOneAsync(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
