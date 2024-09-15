using Homify.BusinessLogic.CompanyOwners;

namespace Homify.WebApi.Controllers.CompanyOwners.Models;

public class CreateCompanyOwnerResponse
{
    public string Id { get; init; }

    public CreateCompanyOwnerResponse(CompanyOwner owner)
    {
        Id = owner.Id;
    }
}
