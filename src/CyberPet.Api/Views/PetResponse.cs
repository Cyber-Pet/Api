﻿using CyberPet.Api.Views.Base;
using System;
using CyberPet.Api.Models;

namespace CyberPet.Api.Views
{
    public class PetResponse : BaseResponse
    {
        public string PetName { get; set; }
        public string? PetImage { get; set; }
        public Guid UserId { get; set; }
        public Guid? BowlId { get; set; }
    }
}
