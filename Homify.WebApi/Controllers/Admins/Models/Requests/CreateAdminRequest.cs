namespace Homify.WebApi.Controllers.Admins.Models.Requests;

public sealed record class CreateAdminRequest
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? LastName { get; init; }
}
