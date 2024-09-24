using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
    Home UpdateMemberList(string homeId, string name);
    void UpdateHomeDevices(string id);
    List<User> GetHomeMembers(string id);
    void UpdateNotificatedList(string homeId, string memberId);
    List<Device> GetHomeDevices(string homeId);
}
