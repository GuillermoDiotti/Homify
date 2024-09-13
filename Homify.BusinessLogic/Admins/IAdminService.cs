using Homify.BusinessLogic.Admins.Entities;

namespace Homify.BusinessLogic.Admins;

public interface IAdminService
{
    Admin Add(CreateAdminArgs args);
}
