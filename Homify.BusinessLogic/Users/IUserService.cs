using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Users;

public interface IUserService
{
    Admin Add(CreateUserArgs args);
    Admin GetById(string id);
    void Delete(string adminId);
}
