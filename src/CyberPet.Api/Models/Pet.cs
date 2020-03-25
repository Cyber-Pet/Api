using CyberPet.Api.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Models
{
    public class Pet : CoreModel
    {
        [Required]
        public string PetName { get; set; }
        public Bowl Bowl { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
