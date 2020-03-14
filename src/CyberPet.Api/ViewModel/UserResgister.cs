using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.ViewModel
{
    public class UserResgister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
