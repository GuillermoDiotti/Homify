using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.HomeUsers;

namespace Homify.BusinessLogic.Notifications.Entities;

public class Notification
{
    public string? Id { get; init; }
    public string? Event { get; init; }
    public HomeDevice? Device { get; init; }
    public string HomeDeviceId { get; init; } = null!;
    public bool IsRead { get; init; }
    public DateTimeOffset? Date { get; init; }
    public string? HomeUserId { get; init; } = null!;
    public string? Detail { get; init; } = null!;
    public HomeUser HomeUser { get; init; } = null!;

    public Notification(string? eventName, HomeDevice device, bool isRead, DateTimeOffset? date, HomeUser hu)
    {
        Id = Guid.NewGuid().ToString();
        Event = eventName;
        Device = device;
        IsRead = isRead;
        Date = date;
        HomeDeviceId = device.Id;
        HomeUser = hu;
        HomeUserId = hu.Id;
    }

    public Notification()
    {
    }
}
