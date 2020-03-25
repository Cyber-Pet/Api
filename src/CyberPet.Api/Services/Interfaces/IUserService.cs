using CyberPet.Api.Models;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IUserService : ICoreCrudService<User> 
    {
        public Task<User> GetByEmail(string email);
    }
}
