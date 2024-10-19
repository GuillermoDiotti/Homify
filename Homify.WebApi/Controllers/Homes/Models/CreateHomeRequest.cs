namespace Homify.WebApi.Controllers.Homes.Models;

public class CreateHomeRequest
{
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitud { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public int MaxMembers { get; set; }
}
