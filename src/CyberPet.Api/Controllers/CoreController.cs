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

        protected ActionResult CustomResponse(string title, object data)
        {
            if (!OperationValid())
            {
                return CustomBadRequest();
            }
            return Ok(new
            {
                title,
                data
            });
        }
        protected ActionResult CustomCreated(string actionName, string title, object data, Guid guid)
        {
            if (!OperationValid())
            {
                return CustomBadRequest();
            }
            return CreatedAtRoute(actionName, new { id = guid },new 
            {
                title,
                data
            });

        }

        protected ActionResult CustomBadRequest()
        {
            var messages = _notifier.GetNotifications().Select(x => x.Message).ToList();
            return BadRequest(new
            {
                title = "Deu Ruim!",
                errors = messages
            });
        }
    }
}
