using CyberPet.Api.Models;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(Token), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var userToken = await _authService.Login(login);
            if (userToken != null)
            {
                return Ok(userToken);
            }
            return Ok("Usuario ou Senha Invalido");
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(User),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserResgister userResgister)
        {
            if (true)
            {
                return StatusCode(409, $"Usuario já cadastrado");
            }
            var user = await _authService.Register(userResgister);
            return Ok(user);
        }
    }
}