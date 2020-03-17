using CyberPet.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CoreController : ControllerBase
    {
        private readonly INotifier _notifier;
        public CoreController(INotifier notifier) => _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        
        protected bool OperationValid() => !_notifier.HaveNotification();

        protected ActionResult CustomResponse(object json)
        {
            if (OperationValid())
            {
                return Ok(json);
            }
            else
            {
                return BadRequest(_notifier.GetNotifications().Select(x => x.Message));
            }
        }
    }
}
