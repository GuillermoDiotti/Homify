using Homify.BusinessLogic.Homes.Entities;

namespace Homify.BusinessLogic.Homes;

public interface IHomePermissionService
{
    HomePermission? GetByValue(string value);
}
