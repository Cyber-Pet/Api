﻿using CyberPet.Api.Views.Base;
using System;
using System.Collections.Generic;

namespace CyberPet.Api.Views
{
    public class ScheduleRequest : BaseRequest
    {
        public Guid PetId { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
