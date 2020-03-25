using CyberPet.Api.Models;
using CyberPet.Api.ViewModel.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.ViewModel
{
    public class UserResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
