using Homify.BusinessLogic.Homes.Entities;

namespace Homify.WebApi.Controllers.Homes.Models.Responses;

public class GetHomesResponse
{
    public string? Id { get; set; }
    public string? Street { get; set; }
    public string? Alias { get; set; }
    public string? Number { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int MaxMembers { get; set; }

    public GetHomesResponse(Home home)
    {
        Id = home.Id;
        Street = home.Street;
        Alias = home.Alias;
        Number = home.Number;
        Latitude = home.Latitude;
        Longitude = home.Longitude;
        MaxMembers = home.MaxMembers;
    }
}
