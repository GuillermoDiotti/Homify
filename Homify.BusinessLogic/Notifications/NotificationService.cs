using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Users;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.Notifications;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IHomeUserService _homeUserService;
    private readonly IUserService _userService;

    public NotificationService(IRepository<Notification> notificationRepository,
        IHomeUserService homeUserService, IUserService userService)
    {
        _notificationRepository = notificationRepository;
        _homeUserService = homeUserService;
        _userService = userService;
    }

    public List<Notification> GetAllByUserId(string userId)
    {
        var notifications = _notificationRepository.GetAll().ToList();
        return notifications.Where(n => n.HomeUser.UserId == userId).ToList();
    }

    public List<Notification> AddPersonDetected(CreateNotificationArgs notification)
    {
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetByHomeId(homeId);
        var returnNotification = new List<Notification>();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var detectedUser = _userService.GetById(notification.PersonDetectedId);
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = "Person Detected",
                    Device = notification.Device,
                    IsRead = false,
                    Date = HomifyDateTime.GetActualDate(),
                    HomeDeviceId = notification.Device.Id,
                    Detail = (detectedUser != null) ? Helpers.GetUserFullName(detectedUser.Name, detectedUser.LastName) : null,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification.Add(noti);
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public List<Notification> AddWindow(CreateGenericNotificationArgs notification)
    {
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetByHomeId(homeId);
        var returnNotification = new List<Notification>();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = notification.Event ?? "Window state switch detected",
                    Device = notification.Device,
                    IsRead = false,
                    Date = HomifyDateTime.GetActualDate(),
                    HomeDeviceId = notification.Device.Id,
                    Detail = notification.Action,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification.Add(noti);
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public List<Notification> AddLamp(CreateGenericNotificationArgs notificationArgs)
    {
        var homeId = notificationArgs.Device.HomeId;
        var homeUsers = _homeUserService.GetByHomeId(homeId);
        var returnNotification = new List<Notification>();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = notificationArgs.Event ?? "Lamp state switch detected",
                    Device = notificationArgs.Device,
                    IsRead = false,
                    Date = HomifyDateTime.GetActualDate(),
                    HomeDeviceId = notificationArgs.Device.Id,
                    Detail = notificationArgs.Action,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification.Add(noti);
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public List<Notification> AddMovement(CreateGenericNotificationArgs notification)
    {
        var homeId = notification.Device.HomeId;
        var homeUsers = _homeUserService.GetByHomeId(homeId);
        var returnNotification = new List<Notification>();
        foreach (var users in homeUsers)
        {
            if (users.IsNotificable)
            {
                var noti = new Notification()
                {
                    Id = Guid.NewGuid().ToString(),
                    Event = "Movement detected in home",
                    Device = notification.Device,
                    IsRead = false,
                    Date = HomifyDateTime.GetActualDate(),
                    HomeDeviceId = notification.Device.Id,
                    Detail = notification.Action,
                    HomeUserId = users.UserId,
                    HomeUser = users,
                };
                returnNotification.Add(noti);
                _notificationRepository.Add(noti);
            }
        }

        return returnNotification;
    }

    public Notification ReadById(string id, User u)
    {
        var noti = _notificationRepository.Get(x => x.Id == id);
        if (noti.HomeUser.UserId != u.Id)
        {
            throw new InvalidOperationException("This notification is not yours");
        }

        noti.IsRead = true;
        _notificationRepository.Update(noti);
        return noti;
    }
}
