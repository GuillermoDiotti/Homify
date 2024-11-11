using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Permissions.HomePermissions;

public interface IHomePermissionService
{
    HomePermission? GetByValue(string value);

    List<HomePermission> ChangeHomeMemberPermissions(bool addDevice, bool listDevice, bool renameDevice, User user, HomeUser? found);
}
