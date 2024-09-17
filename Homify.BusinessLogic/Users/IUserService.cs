using Homify.BusinessLogic.CompanyOwners;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Users;

public interface IUserService
{
    User AddUser(CreateUserArgs args);
    CompanyOwner AddCompanyOwner(CreateUserArgs args);
    User GetById(string id);
    List<User> GetAll();
    void Delete(string userId);
}
