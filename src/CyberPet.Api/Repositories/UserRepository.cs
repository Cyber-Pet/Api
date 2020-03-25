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
        private readonly INotifier _notifier;
        public UserRepository(CyberPetContext context, INotifier notifier)
        {
            _context = context;
            this._notifier = notifier;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (!users.Any())
            {
                _notifier.Add(new Notification("Não existe Usuarios Cadastrados"));
                return null;
            }
            return users;
        }

        public async Task<User> GetOneByIdAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _notifier.Add(new Notification("Usuario não encontrado"));
                return null;
            }
            return user;
        }

        public async Task<User> GetOneBy(Expression<Func<User, bool>> condition)
        {
            User user = await _context.Users.FirstOrDefaultAsync(condition);
            if (user == null)
            {
                _notifier.Add(new Notification("Usuario não encontrado"));
                return null;
            }
            return user;
        }
        public async Task<int> CreateAsync(User newUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);
            if (user != null)
            {
                _notifier.Add(new Notification("Já existe um usuario cadastrado com este E-Mail"));
                return -1;
            }
            await _context.Users.AddAsync(newUser);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            User user = await GetOneByIdAsync(id);
            if (user == null) return -1;
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();

            
        }       

        public async Task<int> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
