namespace Homify.WebApi.Controllers.Devices.Models.Requests;

public class CreateLampRequest
{
    public string? Name { get; set; }
    public bool Active { get; set; }
    public string? Model { get; init; }
    public string? Description { get; init; }
}
