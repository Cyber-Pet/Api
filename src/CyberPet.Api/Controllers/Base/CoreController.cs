using CyberPet.Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace CyberPet.Api.Controllers.Base
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
        protected ActionResult CustomBadRequest(ModelStateDictionary modelStateDictionary)
        {
            var errors = modelStateDictionary.Values.SelectMany(e => e.Errors);

            foreach (var erro in errors)
            {
                var mensage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _notifier.Add(new Models.Notification(mensage));
            }
            return CustomBadRequest();
        }

    }
}
