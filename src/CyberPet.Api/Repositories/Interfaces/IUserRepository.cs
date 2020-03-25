using CyberPet.Api.Models;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    public interface IUserRepository : ICoreRepository<User>
    {
        public Task<User> GetByEmail(string email);
    }
}
