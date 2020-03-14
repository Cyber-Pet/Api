using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
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
        private readonly INotifier notifier;
        public UserRepository(CyberPetContext context, INotifier notifier)
        {
            _context = context;
            this.notifier = notifier;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> ReadOneBy(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.FirstOrDefaultAsync(condition);
        }
        public async Task<int> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            User user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return await _context.SaveChangesAsync();
            }
            else
            {
                notifier.Add(new Notification("Usuario não encontrado"));
            }
            return -1;
        }       

        public async Task<int> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
