using CyberPet.Api.Views.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CyberPet.Api.Views
{
    public class PetRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string PetName { get; set; }

        public string? PetImage { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Guid UserId { get; set; }
    }
}
