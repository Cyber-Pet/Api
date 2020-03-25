using System;

namespace CyberPet.Api.Views
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
    }
}
