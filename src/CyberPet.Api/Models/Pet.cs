using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Models
{
    public class Pet : CoreModel
    {
        [Required]
        public string PetName { get; set; }
    }
}
