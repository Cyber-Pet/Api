using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Base;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Utils;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class UserService : CoreCrudService<User, IUserRepository>, IUserService
    {
        public UserService(INotifier notifier, IUserRepository userRepository) : base(notifier, userRepository) { }

        public override Task<int> CreateAsync(User user)
        {
            user.Password = SecurityUtils.EncryptPassword(user.Password);
            return base.CreateAsync(user);
        }

        public Task<User> GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

    }
}
