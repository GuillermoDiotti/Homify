using Homify.BusinessLogic.Admins.Entities;

namespace Homify.BusinessLogic.Admins;

public interface IAdminService
{
    Admin Add(CreateAdminArgs args);
    Admin GetById(string id);
    void Delete(string adminId);
}
