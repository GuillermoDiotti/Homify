﻿using Homify.BusinessLogic.Devices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Rooms.Entities;

namespace Homify.BusinessLogic.HomeDevices.Entities;
public sealed record class HomeDevice
{
    public string Id { get; init; } = null!;
    public string? CustomName { get; set; } = null!;
    public string HomeId { get; set; } = null!;
    public string DeviceId { get; set; } = null!;
    public Home Home { get; set; } = null!;
    public Device Device { get; set; } = null!;
    public bool Connected { get; set; }
    public string HardwareId { get; set; } = null!;
    public bool IsActive { get; set; }
    public bool IsOn { get; set; }
    public Room? Room { get; set; }

    public HomeDevice()
    {
        Id = Guid.NewGuid().ToString();
        HardwareId = Guid.NewGuid().ToString();
    }
}
