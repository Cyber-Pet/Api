using CyberPet.Api.Models;
using CyberPet.Api.Views;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest user);
        Task<User> Register(UserRequest userResgister);
    }
}
