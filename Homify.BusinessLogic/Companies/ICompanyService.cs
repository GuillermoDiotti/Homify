using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Companies;

public interface ICompanyService
{
    Company Add(CreateCompanyArgs args, User user);
}
