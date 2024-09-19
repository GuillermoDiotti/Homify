namespace Homify.BusinessLogic.Homes.Entities;
public class Home
{
    public string Id { get; init; } = null!;
    public string Street { get; set; } = null!;
    public int Number { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public int MaxMembers { get; set; }

    public Home()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Home(string street, int number, int latitude, int longitude, int maxMembers)
    {
        Id = Guid.NewGuid().ToString();
        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        MaxMembers = maxMembers;
    }
}
