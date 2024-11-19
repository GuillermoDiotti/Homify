using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.BusinessLogic.Permissions;
using Homify.Utility;
using Homify.WebApi.Controllers.Notifications.Models;
using Homify.WebApi.Controllers.Notifications.Models.Requests;
using Homify.WebApi.Controllers.Notifications.Models.Responses;
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
        Helpers.ValidateRequest(request);

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(request.HardwareId);

        var validateDeviceArgs = new ValidateNotificationDeviceArgs(fromDevice, Constants.CAMERA);

        var arguments = new CreateNotificationArgs(
            request.PersonDetectedId ?? string.Empty,
            fromDevice,
            false,
            request.HardwareId);

        var notification = _notificationService.AddPersonDetectedNotification(arguments);

        return notification.Select(n => new CreateNotificationResponse(n)).ToList();
    }

    [HttpPost("window-movement")]
    public List<CreateGenericNotificationResponse> WindowMovementNotification(CreateGenericNotificationRequest request)
    {
        Helpers.ValidateRequest(request);

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(request.HardwareId);

        var validateDeviceArgs = new ValidateNotificationDeviceArgs(fromDevice, Constants.SENSOR);

        var arguments = new CreateGenericNotificationArgs(fromDevice, false, DateTimeOffset.Now, request.HardwareId, request.Action, request.Event);

        var notification = _notificationService.AddWindowNotification(arguments);

        return notification.Select(n => new CreateGenericNotificationResponse(n)).ToList();
    }

    [HttpPost("movement-detected")]
    public List<CreateGenericNotificationResponse> MovementNotification(CreateGenericNotificationRequest req)
    {
        Helpers.ValidateRequest(req);

        var fromDevice = _homeDeviceService.GetHomeDeviceByHardwareId(req.HardwareId);

        Helpers.ValidateNotFound("Device", fromDevice);

        var validateDeviceArgs = new ValidateNotificationDeviceArgs(fromDevice, Constants.CAMERA);

        var arguments = new CreateGenericNotificationArgs(fromDevice, false, DateTimeOffset.Now, req.HardwareId, req.Action, req.Event);

        var notification = _notificationService.AddMovementNotification(arguments);

        return notification.Select(n => new CreateGenericNotificationResponse(n)).ToList();
    }

    [HttpGet]
    [AuthenticationFilter]
    [AuthorizationFilter(PermissionsGenerator.GetUserNotifications)]
    public List<NotificationBasicInfo> ObtainNotifications([FromQuery] string? deviceType, [FromQuery] string? date, [FromQuery] string? read)
    {
        var user = GetUserLogged();
        var list = _notificationService.GetAllByUserId(user.Id);

        if (!string.IsNullOrEmpty(deviceType))
        {
            list = list.Where(n => n?.Device?.Device?.Type.ToLower() == deviceType.ToLower()).ToList();
        }

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

        Helpers.ValidateNotFound("Notification", noti);

        return new UpdateNotificationResponse(noti);
    }
}
