using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Notifications;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IHomeDeviceService _homeDeviceService;

    public NotificationService(IRepository<Notification> notificationRepository, HomeDeviceService homeDeviceService)
    {
        _notificationRepository = notificationRepository;
        _homeDeviceService = homeDeviceService;
    }

    public Notification GetById(string id)
    {
        throw new NotImplementedException();
    }

    public List<Notification> GetAllByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public Notification AddPersonDetectedNotification(CreateNotificationArgs notification)
    {
        return new Notification();
    }

    public Notification ReadNotificationById(string id)
    {
        throw new NotImplementedException();
    }
}
