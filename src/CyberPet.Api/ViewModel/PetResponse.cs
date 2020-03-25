using CyberPet.Api.ViewModel.Base;
using System;

namespace CyberPet.Api.ViewModel
{
    public class PetResponse : BaseResponse
    {
        public string PetName { get; set; }
        public Guid UserId { get; set; }
    }
}
