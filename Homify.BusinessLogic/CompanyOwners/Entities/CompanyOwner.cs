using Homify.BusinessLogic.Companies.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.CompanyOwners.Entities;

public sealed record class CompanyOwner : User
{
    public Company? Company { get; set; }
    public bool IsIncomplete { get; set; }

    public CompanyOwner()
    {
        IsIncomplete = true;
    }
}
