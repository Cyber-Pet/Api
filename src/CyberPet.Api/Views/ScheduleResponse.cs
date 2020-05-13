using CyberPet.Api.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Views
{
    public class ScheduleResponse : BaseResponse
    {
        public Guid PetId { get; set; }
         public int Hour { get; set; }
        public int Minutes { get; set; }
    }

}
