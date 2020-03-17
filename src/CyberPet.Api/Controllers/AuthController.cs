using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
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
    public class AuthController : CoreController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, INotifier notifier) : base(notifier)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody]LoginViewModel login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userToken = await _authService.Login(login);
            if (userToken != null)
            {
                return Ok(userToken);
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(User),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserResgisterViewModel userResgister)
        {
            var user = await _authService.Register(userResgister);
            return CustomResponse(user);
        }
    }
}