using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Notifications;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IHomeDeviceService _homeDeviceService;
    private readonly IHomeUserService _homeUserService;

    public NotificationService(IRepository<Notification> notificationRepository, IHomeDeviceService homeDeviceService, IHomeUserService homeUserService)
    {
        _notificationRepository = notificationRepository;
        _homeDeviceService = homeDeviceService;
        _homeUserService = homeUserService;
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
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetHomeUsersByHomeId(homeId);
        var returnNotification = new Notification();
        foreach (var users in homeUsers)
        {
            if(users.IsNotificable)
            {
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = "Persona Detectada",
                    Device = notification.Device,
                    IsRead = false,
                    Date = notification.Date,
                    HomeDeviceId = notification.Device.Id,
                    DetectedUserId = notification.PersonDetectedId,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification = noti;
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public Notification ReadNotificationById(string id)
    {
        throw new NotImplementedException();
    }
}
