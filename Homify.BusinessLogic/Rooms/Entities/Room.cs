using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;

namespace Homify.BusinessLogic.Rooms.Entities;

public sealed record class Room
{
    public string Id { get; init; }
    public string? Name { get; set; }
    public List<HomeDevice>? Devices { get; set; }
    public Home? Home { get; set; }
    public string? HomeId { get; set; }

    public Room(string name, Home home)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Home = home;
        Devices = [];
        HomeId = home.Id;
    }

    public Room()
    {
        Id = Guid.NewGuid().ToString();
    }
}
