using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Notifications;

public interface INotificationService
{
    List<Notification> GetAllByUserId(string userId);
    List<Notification> AddPersonDetectedNotification(CreateNotificationArgs notification);
    List<Notification> AddWindowNotification(CreateGenericNotificationArgs notification);
    List<Notification> AddMovementNotification(CreateGenericNotificationArgs notification);
    Notification ReadNotificationById(string id, User u);
}
