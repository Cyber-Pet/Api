using System.Collections.Generic;

namespace CyberPet.Api.Models.Interfaces
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Add(Notification notification);
        void Add(string message);
    }
}
