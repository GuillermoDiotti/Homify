﻿using Homify.BusinessLogic.Notifications.Entities;

namespace Homify.WebApi.Controllers.Notifications.Models.Responses;

public sealed record class CreateNotificationResponse
{
    public string? Id { get; init; }
    public bool IsRead { get; init; }
    public string Event { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string HardwareId { get; init; } = null!;
    public string Date { get; init; }
    public string PersonDetected { get; init; } = null!;

    public CreateNotificationResponse(Notification n)
    {
        Id = n.Id;
        IsRead = n.IsRead;
        Event = n.Event;
        DeviceId = n.HomeDeviceId;
        HardwareId = n.Device!.HardwareId;
        Date = n.Date!;
        PersonDetected = n.Detail;
    }
}
