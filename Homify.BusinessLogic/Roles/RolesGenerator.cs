using Homify.BusinessLogic.SystemPermissions;
using Homify.Utility;

namespace Homify.BusinessLogic.Roles;

public static class RolesGenerator
{
    public static Role Admin()
    {
        var admin = new Role(Constants.ADMINISTRATOR, PermissionsGenerator.GetAdminPermissions());
        admin.Id = Constants.ADMINISTRATORID;
        return admin;
    }

    public static Role CompanyOwner()
    {
        var owner = new Role(Constants.COMPANYOWNER, PermissionsGenerator.GetCompanyOwnerPermissions());
        owner.Id = Constants.COMPANYOWNERID;
        return owner;
    }

    public static Role HomeOwner()
    {
        var owner = new Role(Constants.HOMEOWNER, PermissionsGenerator.GetHomeOwnerPermissions());
        owner.Id = Constants.HOMEOWNERID;
        return owner;
    }
}
