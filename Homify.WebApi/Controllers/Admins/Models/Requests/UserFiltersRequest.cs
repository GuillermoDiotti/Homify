namespace Homify.WebApi.Controllers.Admins.Models.Requests;

public sealed record class UserFiltersRequest
{
    public string? Limit { get; init; }
    public string? Offset { get; init; }
    public string? Role { get; init; }
    public string? FullName { get; init; }
}
