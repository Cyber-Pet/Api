using CyberPet.Api.Models.Base;
using System;
using System.Collections.Generic;

namespace CyberPet.Api.Models
{
    public class Schedule : CoreModel
    {
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }
        public DateTime Time { get; set; }
        public List<DayOfWeek> DaysOfWeek { get; set; }
    }
}
