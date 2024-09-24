namespace Homify.WebApi.Controllers.Devices.Models;

public sealed record class CreateSensorRequest
{
    public string? Name { get; init; }
    public string? Model { get; init; }
    public string? Description { get; init; }
    public List<string>? Photos { get; init; }
    public string? PpalPicture { get; init; }
}
