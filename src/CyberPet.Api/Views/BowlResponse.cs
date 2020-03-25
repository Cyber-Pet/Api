using CyberPet.Api.Views.Base;
using System;

namespace CyberPet.Api.Views
{
    public class BowlResponse : BaseResponse
    {
        public string Token { get; set; }
        public Guid PetId { get; set; }
    }
}
