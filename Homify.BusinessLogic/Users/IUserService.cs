using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Users;

public interface IUserService
{
    Admin AddAdmin(CreateUserArgs args);
    CompanyOwner AddCompanyOwner(CreateUserArgs args);
    User GetById(string id);
    void Delete(string userId);
}
