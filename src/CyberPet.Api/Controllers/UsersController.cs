using CyberPet.Api.Models;
using CyberPet.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>),200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allUsers = await _userService.ReadAllAsync();
            return Ok(allUsers);
    }
    }
}