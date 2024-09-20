using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HouseOwner;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes.Entities;
public class Home
{
    public string Id { get; init; } = null!;
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string MaxMembers { get; set; } = null!;
    public HomeOwner Owner { get; set; } = null!;
    public List<User> Members { get; set; } = null!;
    public List<Device> Devices {  get; set; } = null!;

    public Home()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Home(string street, string number, string latitude, string longitude, string maxMembers, HomeOwner owner, List<User> members, List<Device> devices)
    {
        Id = Guid.NewGuid().ToString();
        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        MaxMembers = maxMembers;
        Owner = owner;
        Members = members;
        Devices = devices;
    }
}
