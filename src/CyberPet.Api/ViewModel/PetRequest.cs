using CyberPet.Api.ViewModel.Base;
using System;

namespace CyberPet.Api.ViewModel
{
    public class PetRequest : BaseRequest
    {
        public string PetName { get; set; }
        public Guid UserId { get; set; }
    }
}
