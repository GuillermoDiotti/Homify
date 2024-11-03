using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Companies;

public interface ICompanyService
{
    Company Add(CreateCompanyArgs args, User user);
    Company? GetByUserId(string userId);
    List<Company> GetAll(string? owner = null, string? company = null);
}
