using CyberPet.Api.Models;
using CyberPet.Api.ViewModel;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Token> Login(Login user);
        Task<User> Register(UserResgister userResgister);
    }
}
