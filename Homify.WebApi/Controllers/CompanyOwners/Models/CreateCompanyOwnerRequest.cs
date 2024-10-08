namespace Homify.WebApi.Controllers.CompanyOwners.Models;

public class CreateCompanyOwnerRequest
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? LastName { get; init; }
}
