namespace Homify.WebApi.Controllers.Devices.Models.Requests;

public sealed record class CreateLampRequest
{
    public string? Name { get; set; }
    public bool Active { get; set; }
    public string? Model { get; init; }
    public string? Description { get; init; }
    public List<string>? Photos { get; init; }
    public string? PpalPicture { get; init; }
}
