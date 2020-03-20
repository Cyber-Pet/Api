using System.Collections.Generic;

namespace CyberPet.Api.Models
{
    public class User : CoreModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
