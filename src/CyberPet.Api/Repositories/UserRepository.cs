using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Base;
using CyberPet.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class UserRepository : CoreRepository<User>, IUserRepository
    {
        public UserRepository(CyberPetContext context, INotifier notifier) : base(context, notifier) { }

        public override async Task<int> CreateAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == entity.Email.ToLower());
            if (user == null)
            {
                return await base.CreateAsync(entity);
            }
            _notifier.Add("Já existe um usuario cadastrado com este email");
            return -1;
            
        }
        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                return user;
            }
            _notifier.Add("Usuario não encontrado");
            return null;
        }
    }
}
