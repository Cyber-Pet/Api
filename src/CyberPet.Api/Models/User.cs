namespace CyberPet.Api.Models
{
    public class User : CoreModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Pet Pet { get; set; }
    }
}
