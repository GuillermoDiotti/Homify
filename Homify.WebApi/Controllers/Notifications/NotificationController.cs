using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Notifications;
using Homify.BusinessLogic.Notifications.Entities;
using Homify.Exceptions;
using Homify.WebApi.Controllers.Notifications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homify.WebApi.Controllers.Notifications;

[ApiController]
[Route("notifications")]
public class NotificationController
{
    private readonly INotificationService _notificationService;
    private readonly IDeviceService _deviceService;

    public NotificationController(INotificationService notificationService, IDeviceService deviceService)
    {
        _notificationService = notificationService;
        _deviceService = deviceService;
    }

    [HttpPost]
    public CreateNotificationResponse Create(CreateNotificationRequest request)
    {
        if (request == null)
        {
            throw new NullRequestException("Request cannot be null.");
        }

        var fromDevice = _deviceService.GetById(request.DeviceId);

        if (fromDevice == null)
        {
            throw new NotFoundException("Device not found.");
        }

        var arguments = new CreateNotificationArgs(request.Event, fromDevice, false, request.Date);

        var invitation = _notificationService.AddNotification(arguments);

        return new CreateNotificationResponse(invitation);
    }
}
