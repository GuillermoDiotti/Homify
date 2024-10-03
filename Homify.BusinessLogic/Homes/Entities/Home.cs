using Homify.BusinessLogic.HomeDevices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.HomeUsers;

namespace Homify.BusinessLogic.Homes.Entities;
public class Home
{
    public string Id { get; init; } = null!;
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public int MaxMembers { get; set; }
    public HomeOwner Owner { get; set; } = null!;
    public List<HomeDevice> Devices { get; set; } = null!;
    public List<HomeUser> Members { get; set; } = null!;

    public string OwnerId { get; set; } = null!;

    public Home()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Home(string street, string number, string latitude, string longitude,
        int maxMembers, HomeOwner owner, List<HomeDevice> devices, List<HomeUser> notificated)
    {
        Id = Guid.NewGuid().ToString();
        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        MaxMembers = maxMembers;
        Owner = owner;
        Devices = devices;
        Members = notificated;
        OwnerId = owner.Id;
    }
}
