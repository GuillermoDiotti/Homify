namespace Homify.BusinessLogic.Homes.Entities;
public class Home
{
    public string Id { get; init; } = null!;
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string MaxMembers { get; set; } = null!;

    public Home()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Home(string street, string number, string latitude, string longitude, string maxMembers)
    {
        Id = Guid.NewGuid().ToString();
        Street = street;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        MaxMembers = maxMembers;
    }
}
