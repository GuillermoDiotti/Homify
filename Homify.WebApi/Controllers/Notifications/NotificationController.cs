using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Notifications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Notifications;

[ApiController]
[Route("notifications")]
public class NotificationController : HomifyControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IHomeDeviceService _homeDeviceService;

    public NotificationController(INotificationService notificationService, IHomeDeviceService homeDeviceService)
    {
        _notificationService = notificationService;
        _homeDeviceService = homeDeviceService;
    }

    [HttpPost("/person-detected")]
    public CreateNotificationResponse PersonDetectedNotification(CreateNotificationRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null.");
        }

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(request.DeviceId);

        if (fromDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        var arguments = new CreateNotificationArgs(request.PersonDetectedId, fromDevice, false, request.Date, request.HardwareId);

        var invitation = _notificationService.AddPersonDetectedNotification(arguments);

        return new CreateNotificationResponse(invitation);
    }

    [HttpGet]
    public List<NotificationBasicInfo> ObtainNotifications([FromQuery] string user = "")
    {
        var list = _notificationService.GetAllByUserId(user);
        var result = new List<NotificationBasicInfo>();
        foreach (var noti in list)
        {
            result.Add(new NotificationBasicInfo(noti));
        }

        return result;
    }

    [HttpPut("{notificationId}")]
    public CreateNotificationResponse UpdateNotification([FromRoute] string notificationId)
    {
        var noti = _notificationService.ReadNotificationById(notificationId);

        if (noti == null)
        {
            throw new NotFoundException("Notification not found");
        }

        return new CreateNotificationResponse(noti);
    }
}
