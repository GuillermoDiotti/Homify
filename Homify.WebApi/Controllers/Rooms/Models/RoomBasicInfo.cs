using Homify.BusinessLogic.Rooms.Entities;

namespace Homify.WebApi.Controllers.Rooms.Models;

public sealed record class RoomBasicInfo
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public RoomBasicInfo(Room r)
    {
        Id = r.Id;
        Name = r.Name;
    }
}
