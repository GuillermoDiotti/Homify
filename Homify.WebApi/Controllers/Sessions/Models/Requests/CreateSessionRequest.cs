namespace Homify.WebApi.Controllers.Sessions.Models.Requests;

public sealed record class CreateSessionRequest
{
    public string? Email { get; init; }
    public string? Password { get; init; }
}
