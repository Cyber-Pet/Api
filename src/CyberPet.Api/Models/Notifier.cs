using CyberPet.Api.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CyberPet.Api.Models
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;
        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        public void Add(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Add(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }
    }
}
