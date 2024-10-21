namespace Homify.WebApi.Controllers.Rooms.Models;

public class CreateRoomResponse
{
    public string Id { get; init; }

    public CreateRoomResponse(string id)
    {
        Id = id;
    }
}
