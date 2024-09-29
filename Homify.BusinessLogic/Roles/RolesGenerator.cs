using Homify.BusinessLogic.SystemPermissions;
using Homify.Utility;

namespace Homify.BusinessLogic.Roles;

public static class RolesGenerator
{
    public static Role Admin()
    {
        return new Role(Constants.ADMINISTRATOR, PermissionsGenerator.GetAdminPermissions());
    }

    public static Role CompanyOwner()
    {
        return new Role(Constants.COMPANYOWNER, PermissionsGenerator.GetCompanyOwnerPermissions());
    }

    public static Role HomeOwner()
    {
        return new Role(Constants.HOMEOWNER, PermissionsGenerator.GetHomeOwnerPermissions());
    }
}
