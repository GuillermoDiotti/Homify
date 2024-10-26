using Homify.BusinessLogic.Admins.Entities;
using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.CompanyOwners.Entities;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.HomeOwners.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Users;

public interface IUserService
{
    Admin AddAdmin(CreateUserArgs args);
    CompanyOwner AddCompanyOwner(CreateUserArgs args);
    HomeOwner AddHomeOwner(CreateHomeOwnerArgs args);
    User? GetById(string id);
    List<User> GetAll();
    void Delete(string userId);
}
