namespace Homify.WebApi.Controllers.Rooms.Models.Requests;

public sealed record class CreateRoomRequest
{
    public string? Name { get; set; }
    public string? HomeId { get; set; }
}
