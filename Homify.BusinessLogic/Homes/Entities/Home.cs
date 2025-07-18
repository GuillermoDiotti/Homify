﻿using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Rooms.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes.Entities;
public sealed record class Home
{
    public string Id { get; init; } = null!;
    public string Street { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public int MaxMembers { get; set; }
    public User Owner { get; set; } = null!;
    public List<HomeDevice> Devices { get; set; } = null!;
    public List<HomeUser> Members { get; set; } = null!;
    public List<Room>? Rooms { get; set; } = null!;

    public string OwnerId { get; set; } = null!;

    public Home()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Home(string street, string number, string latitude, string longitude,
        int maxMembers, User owner, List<HomeDevice> devices, List<HomeUser> notificated)
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
