using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
    Home UpdateMemberList(string name);
    void UpdateHomeDevices(string id);
    List<User> GetHomeMembers();
    void UpdateNotificatedList(string id);
}
