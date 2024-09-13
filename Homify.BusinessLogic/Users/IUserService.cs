using Homify.BusinessLogic.Admins.Entities;

namespace Homify.BusinessLogic.Users;

public interface IUserService
{
    Admin Add(CreateAdminArgs args);
    Admin GetById(string id);
    void Delete(string adminId);
}
