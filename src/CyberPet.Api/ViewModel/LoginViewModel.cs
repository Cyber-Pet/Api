using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O Email informado não é um email valido")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
