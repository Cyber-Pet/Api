using CyberPet.Api.Views.Base;
using System;

namespace CyberPet.Api.Views
{
    public class BowlRequest : BaseRequest
    {
        public Guid PetId { get; set; }
    }
}
