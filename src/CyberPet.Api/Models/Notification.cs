using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Models
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
