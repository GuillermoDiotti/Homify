namespace Homify.WebApi.Controllers.Devices.Models.Requests;

public sealed record class CreateCameraRequest
{
    public string? Name { get; init; }
    public string? Model { get; init; }
    public bool? IsExterior { get; init; }
    public bool? IsInterior { get; init; }
    public bool? MovementDetection { get; init; }
    public bool? PeopleDetection { get; init; }
    public string? Description { get; init; }
    public List<string>? Photos { get; init; }
    public string? PpalPicture { get; init; }
}
