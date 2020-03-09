using CyberPet.Api.Models;
using CyberPet.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allUsers = await _userService.ReadAllAsync();
            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReadOneAsync(Guid id)
        {
            var user = await _userService.ReadOneAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(User userToUpdate)
        {
            var updatedUser = await _userService.UpdateAsync(userToUpdate);
            return Ok(updatedUser);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync(User userToCreate)
        {
            var createdUser = await _userService.CreateAsync(userToCreate);
            return Ok(createdUser);
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deletedUser = await _userService.DeleteAsync(id);
            return Ok(deletedUser);
        }
    }
}