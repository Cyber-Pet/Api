using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Utils;
using CyberPet.Api.Views;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly INotifier _notifier;
        public AuthService(IUserService userService, IMapper mapper, IConfiguration configuration, INotifier notifier)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
            _notifier = notifier;
        }

        public async Task<LoginResponse> Login(LoginRequest userLogin)
        {
            var user = await _userService.GetByEmail(userLogin.Email);
            if (user == null) return null;
            if (user.Password == SecurityUtils.EncryptPassword(userLogin.Password))
            {
                LoginResponse userToken = _mapper.Map<LoginResponse>(user);
                userToken.token = GenerateToken(user);
                return userToken;
            }
            _notifier.Add(new Notification("Senha Incorreta"));
            return null;
        }

        public async Task<User> Register(UserRequest userResgister)
        {
            User user = _mapper.Map<User>(userResgister);
            await _userService.CreateAsync(user);
            return user;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();


            byte[] secret = Encoding.ASCII.GetBytes(_configuration.GetSection("SecuritSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
