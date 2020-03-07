using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CyberPetContext _context;
        public UserRepository(CyberPetContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> DeleteAsync(Guid id)
        {

            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> ReadAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ReadOneAsync(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateAsync(Guid id, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
