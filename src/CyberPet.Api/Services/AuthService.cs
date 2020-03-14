using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Utils;
using CyberPet.Api.ViewModel;
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
        public AuthService(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TokenViewModel> Login(LoginViewModel userLogin)
        {
            var user = await _userService.ReadOneBy(x => x.Email == userLogin.Email && x.Password == SecurityUtils.EncryptPassword(userLogin.Password));
            if (user == null)
            {
                return _mapper.Map<TokenViewModel>(user);
            }
            TokenViewModel userToken = _mapper.Map<TokenViewModel>(user);
            userToken.token = GenerateToken(user);
            return userToken;
        }

        public async Task<User> Register(UserResgisterViewModel userResgister)
        {
            var newUser = await _userService.CreateAsync(_mapper.Map<User>(userResgister));
            return newUser;
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
