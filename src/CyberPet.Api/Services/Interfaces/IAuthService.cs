using CyberPet.Api.Models;
using CyberPet.Api.ViewModel;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenViewModel> Login(LoginViewModel user);
        Task<User> Register(UserRequest userResgister);
    }
}
