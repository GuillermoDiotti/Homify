using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Notifications;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IHomeDeviceService _homeDeviceService;
    private readonly IHomeUserService _homeUserService;
    private readonly IUserService _userService;

    public NotificationService(IRepository<Notification> notificationRepository, IHomeDeviceService homeDeviceService,
        IHomeUserService homeUserService, IUserService userService)
    {
        _notificationRepository = notificationRepository;
        _homeDeviceService = homeDeviceService;
        _homeUserService = homeUserService;
        _userService = userService;
    }

    public Notification GetById(string id)
    {
        throw new NotImplementedException();
    }

    public List<Notification> GetAllByUserId(string userId)
    {
        var notifications = _notificationRepository.GetAll().ToList();
        return notifications.Where(n => n.HomeUser.UserId == userId).ToList();
    }

    public Notification AddPersonDetectedNotification(CreateNotificationArgs notification)
    {
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetHomeUsersByHomeId(homeId);
        var returnNotification = new Notification();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var detectedUser = _userService.GetById(users.UserId);
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = "Person Detected",
                    Device = notification.Device,
                    IsRead = false,
                    Date = notification.Date,
                    HomeDeviceId = notification.Device.Id,
                    DetectedUserId = detectedUser?.Id,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification = noti;
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public Notification AddWindowNotification(CreateGenericNotificationArgs notification)
    {
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetHomeUsersByHomeId(homeId);
        var returnNotification = new Notification();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var detectedUser = _userService.GetById(users.UserId);
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = "Window state switch detected",
                    Device = notification.Device,
                    IsRead = false,
                    Date = notification.Date,
                    HomeDeviceId = notification.Device.Id,
                    DetectedUserId = detectedUser?.Id,
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
