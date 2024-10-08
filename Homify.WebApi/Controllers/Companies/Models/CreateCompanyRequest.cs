namespace Homify.WebApi.Controllers.Companies.Models;

public class CreateCompanyRequest
{
    public string? Name { get; init; }
    public string? LogoUrl { get; init; }
    public string? Rut { get; init; }
}
