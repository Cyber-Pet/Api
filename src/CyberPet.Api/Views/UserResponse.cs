using CyberPet.Api.Models;
using CyberPet.Api.Views.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Views
{
    public class UserResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
