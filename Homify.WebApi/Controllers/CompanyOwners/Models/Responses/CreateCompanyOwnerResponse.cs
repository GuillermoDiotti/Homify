using Homify.BusinessLogic.CompanyOwners.Entities;

namespace Homify.WebApi.Controllers.CompanyOwners.Models.Responses;

public class CreateCompanyOwnerResponse
{
    public string Id { get; init; }

    public CreateCompanyOwnerResponse(CompanyOwner owner)
    {
        Id = owner.Id;
    }
}
