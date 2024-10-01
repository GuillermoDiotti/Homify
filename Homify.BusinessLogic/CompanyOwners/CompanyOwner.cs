using Homify.BusinessLogic.Companies;
using Homify.BusinessLogic.Roles;
using Homify.BusinessLogic.Users.Entities;
using Homify.Utility;

namespace Homify.BusinessLogic.CompanyOwners;

public class CompanyOwner : User
{
    public Company? Company { get; set; }
    public bool IsIncomplete { get; set; }
    public CompanyOwner()
    {
        IsIncomplete = true;
        RoleId = Constants.COMPANYOWNERID;
    }
}
