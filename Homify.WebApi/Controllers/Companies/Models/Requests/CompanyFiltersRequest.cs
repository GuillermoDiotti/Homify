namespace Homify.WebApi.Controllers.Companies.Models.Requests;

public sealed record class CompanyFiltersRequest
{
    public string? Limit { get; init; }
    public string? Offset { get; init; }
    public string? OwnerFullName { get; init; }
    public string? Company { get; init; }
}
