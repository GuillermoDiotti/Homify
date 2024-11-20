namespace Homify.WebApi.Controllers.Session.Models.Requests;

public class CreateSessionRequest
{
    public string? Email { get; init; }
    public string? Password { get; init; }
}
