using CyberPet.Api.Views.Base;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Views
{
    public class UserRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Email")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Senha")]
        [MinLength(6, ErrorMessage = "A Senha deve conter no minimo {1} Caracteres")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Nome")]
        public string Name { get; set; }
    }
}
