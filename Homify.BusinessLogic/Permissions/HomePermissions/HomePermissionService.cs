using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Permissions.HomePermissions.Entities;
using Homify.BusinessLogic.Users.Entities;
using Homify.DataAccess.Repositories;

namespace Homify.BusinessLogic.Permissions.HomePermissions;

public class HomePermissionService : IHomePermissionService
{
    private readonly IRepository<HomePermission> _repository;

    public HomePermissionService(IRepository<HomePermission> repository)
    {
        _repository = repository;
    }

    public HomePermission? GetByValue(string value)
    {
        return _repository.Get(x => x.Value == value);
    }

    public List<HomePermission> ChangeHomeMemberPermissions(bool addDevice, bool listDevice, User user, HomeUser? found)
    {
        if (user.Id != found.Home.OwnerId)
        {
            throw new InvalidOperationException("You must be the owner of this home");
        }

        var list = new List<HomePermission>();
        if (addDevice)
        {
            var permission = GetByValue(PermissionsGenerator.MemberCanAddDevice);
            if (permission != null)
            {
                list.Add(permission);
            }
        }

        if (listDevice)
        {
            var permission = GetByValue(PermissionsGenerator.MemberCanListDevices);
            if (permission != null)
            {
                list.Add(permission);
            }
        }

        return list;
    }
}
