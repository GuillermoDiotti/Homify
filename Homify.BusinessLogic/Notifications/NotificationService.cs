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
        var device = _homeDeviceService.GetHomeDeviceByHardwareId(notification.HardwareId);
        if (device == null)
        {
            throw new ArgumentException("Device not found");
        }

        var returnNotification = new Notification()
        {
            Id = Guid.NewGuid().ToString(),
            Event = "Persona Detectada",
            Device = device,
            IsRead = notification.IsRead,
            Date = notification.Date,
            HomeDeviceId = device.Id,
            DetectedUserId = notification.PersonDetectedId,
        };
        _notificationRepository.Add(returnNotification);
        return returnNotification;
    }

    public Notification ReadNotificationById(string id)
    {
        throw new NotImplementedException();
    }
}
