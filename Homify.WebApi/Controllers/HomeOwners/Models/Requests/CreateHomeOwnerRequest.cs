namespace Homify.WebApi.Controllers.HomeOwners.Models.Requests;

public sealed record class CreateHomeOwnerRequest
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? LastName { get; init; }
    public string? ProfilePicUrl { get; init; }
}
