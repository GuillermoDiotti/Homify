using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.CompanyOwners.Entities;

public class CompanyOwner : User
{
    public Company? Company { get; set; }
    public bool IsIncomplete { get; set; }

    public CompanyOwner()
    {
        IsIncomplete = true;
    }
}
