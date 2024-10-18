using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Utility;
using Homify.Exceptions;
using Homify.Utility;
using Homify.WebApi.Controllers.Notifications.Models;
using Homify.WebApi.Filters;
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

    [HttpPost("person-detected")]
    public List<CreateNotificationResponse> PersonDetectedNotification(CreateNotificationRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null.");
        }

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(request.HardwareId);

        if (fromDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (fromDevice.Device.Type != Constants.CAMERA)
        {
            throw new InvalidOperationException("Only sensors are supported.");
        }

        if (!fromDevice.IsActive)
        {
            throw new InvalidOperationException("Device is not active");
        }

        var arguments = new CreateNotificationArgs(
            request.PersonDetectedId ?? string.Empty,
            fromDevice,
            false,
            request.HardwareId);

        var notification = _notificationService.AddPersonDetectedNotification(arguments);
        var ret = new List<CreateNotificationResponse>();
        foreach (var n in notification)
        {
            ret.Add(new CreateNotificationResponse(n));
        }

        return ret;
    }

    [HttpPost("window-movement")]
    public List<CreateGenericNotificationResponse> WindowMovementNotification(CreateGenericNotificationRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null.");
        }

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(request.HardwareId);

        if (fromDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (fromDevice.Device.Type != Constants.SENSOR)
        {
            throw new InvalidOperationException("Only sensors are supported.");
        }

        if (!fromDevice.IsActive)
        {
            throw new InvalidOperationException("Device is not active");
        }

        var arguments = new CreateGenericNotificationArgs(fromDevice, false, DateTimeOffset.Now, request.HardwareId, request.Action);

        var notification = _notificationService.AddWindowNotification(arguments);
        var ret = new List<CreateGenericNotificationResponse>();
        foreach (var n in notification)
        {
            ret.Add(new CreateGenericNotificationResponse(n));
        }

        return ret;
    }

    [HttpPost("movement-detected")]
    public List<CreateGenericNotificationResponse> MovementNotification(CreateGenericNotificationRequest req)
    {
        if (req == null)
        {
            throw new NullRequestException("Exception cannot be null");
        }

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(req.HardwareId);

        if (fromDevice == null)
        {
            throw new NotFoundException("Device not found");
        }

        if (fromDevice.Device.Type != Constants.CAMERA)
        {
            throw new InvalidOperationException("Only sensors are supported.");
        }

        if (!fromDevice.IsActive)
        {
            throw new InvalidOperationException("Device is not active");
        }

        var arguments = new CreateGenericNotificationArgs(fromDevice, false, DateTimeOffset.Now, req.HardwareId, req.Action);

        var notification = _notificationService.AddMovementNotification(arguments);

        var ret = new List<CreateGenericNotificationResponse>();
        foreach (var n in notification)
        {
            ret.Add(new CreateGenericNotificationResponse(n));
        }

        return ret;
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetUserNotifications)]
    public List<NotificationBasicInfo> ObtainNotifications([FromQuery] string? eventTriggered, [FromQuery] string? date, [FromQuery] string? read)
    {
        var user = GetUserLogged();
        var list = _notificationService.GetAllByUserId(user.Id);

        if (!string.IsNullOrEmpty(eventTriggered))
        {
            list = list.Where(n => n.Event == eventTriggered).ToList();
        }

        /*if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out DateTime parsedDate))
        {
            list = list.Where(n => n.Date == parsedDate.Date).ToList();
        }*/

        if (!string.IsNullOrEmpty(date))
        {
            var veryfyDateFormat = HomifyDateTime.Parse(date);
            list = list.Where(n => n.Date == veryfyDateFormat).ToList();
        }

        if (!string.IsNullOrEmpty(read) && bool.TryParse(read, out var isRead))
        {
            list = list.Where(n => n.IsRead == isRead).ToList();
        }

        var result = list.Select(n => new NotificationBasicInfo(n)).ToList();
        return result;
    }

    [HttpPut("{notificationId}")]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.UpdateUserNotification)]
    public UpdateNotificationResponse UpdateNotification([FromRoute] string notificationId)
    {
        var user = GetUserLogged();
        var noti = _notificationService.ReadNotificationById(notificationId, user);

        if (noti == null)
        {
            throw new NotFoundException("Notification not found");
        }

        return new UpdateNotificationResponse(noti);
    }
}
