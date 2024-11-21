namespace Homify.WebApi.Controllers.Rooms.Models.Responses;

public sealed record class CreateRoomResponse
{
    public string Id { get; init; }

    public CreateRoomResponse(string id)
    {
        Id = id;
    }
}
