﻿using CyberPet.Api.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Models
{
    public class User : CoreModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }
        public ICollection<Pet> Pets { get; set; }
        public string Role { get; set; }
    }
}
