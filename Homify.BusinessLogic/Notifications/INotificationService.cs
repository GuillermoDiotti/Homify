using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Notifications;

public interface INotificationService
{
    List<Notification> GetAllByUserId(string userId);
    List<Notification> AddPersonDetected(CreateNotificationArgs notification);
    List<Notification> AddWindow(CreateGenericNotificationArgs notification);
    List<Notification> AddMovement(CreateGenericNotificationArgs notification);
    List<Notification> AddLamp(CreateGenericNotificationArgs notification);
    Notification ReadById(string id, User u);
}
