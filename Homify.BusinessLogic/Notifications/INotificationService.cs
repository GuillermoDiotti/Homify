using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.BusinessLogic.Notifications;

public interface INotificationService
{
    Notification GetById(string id);
    List<Notification> GetAllByUserId(string userId);
    Notification AddPersonDetectedNotification(CreateNotificationArgs notification);
    Notification AddWindowNotification(CreateGenericNotificationArgs notification);
    Notification AddMovementNotification(CreateGenericNotificationArgs notification);
    Notification ReadNotificationById(string id);
}
