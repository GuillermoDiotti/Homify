using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Notifications;

public interface INotificationService
{
    List<Notification> GetAllByUserId(string userId);
    Notification AddPersonDetectedNotification(CreateNotificationArgs notification);
    Notification AddWindowNotification(CreateGenericNotificationArgs notification);
    Notification AddMovementNotification(CreateGenericNotificationArgs notification);
    Notification ReadNotificationById(string id, User u);
}
