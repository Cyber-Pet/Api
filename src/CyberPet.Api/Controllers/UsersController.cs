using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CoreController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, INotifier notifier) : base(notifier)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var allUsers = await _userService.GetAllAsync();
            return Ok(allUsers);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
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