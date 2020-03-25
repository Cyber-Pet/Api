using CyberPet.Api.Models.Base;
using System;

namespace CyberPet.Api.Models
{
    public class Bowl : CoreModel
    {
        public string Token { get; set; }
        
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
