using CyberPet.Api.Models;
using CyberPet.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var newUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task<User> DeleteAsync(Guid id)
        {
            var deletedUser = _context.Users.Remove(await ReadOneAsync(id));
            await _context.SaveChangesAsync();
            return deletedUser.Entity;
        }

        public async Task<IEnumerable<User>> ReadAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> ReadOneAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> ReadOneBy(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.FirstOrDefaultAsync(condition);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
