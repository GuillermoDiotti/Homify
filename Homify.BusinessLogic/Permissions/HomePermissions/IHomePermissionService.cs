using Homify.BusinessLogic.Permissions.HomePermissions.Entities;

namespace Homify.BusinessLogic.Permissions.HomePermissions;

public interface IHomePermissionService
{
    HomePermission? GetByValue(string value);
}
