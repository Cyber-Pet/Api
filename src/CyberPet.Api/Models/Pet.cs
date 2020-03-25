using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberPet.Api.Models
{
    public class Pet : CoreModel
    {
        [Required]
        public string PetName { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
