namespace Homify.WebApi.Controllers.Homes.Models;

public class CreateHomeRequest
{
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitud { get; set; } = null!;
    public string MaxMembers { get; set; } = null!;
}
