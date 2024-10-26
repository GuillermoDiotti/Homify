using Homify.BusinessLogic.Companies;

namespace Homify.WebApi.Controllers.Companies.Models.Responses;

public sealed record class CreateCompanyResponse
{
    public string Id { get; init; }

    public CreateCompanyResponse(Company c)
    {
        Id = c.Id;
    }
}
