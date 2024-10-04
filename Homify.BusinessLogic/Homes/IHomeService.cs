using Homify.BusinessLogic.Devices;
using Homify.BusinessLogic.HomeOwners;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
    Home? GetHomeById(string id);
    Home UpdateMemberList(string homeId, HomeUser homeOwner);
    void UpdateHomeDevices(string deviceid, string homeid, User user);
    List<HomeUser> GetHomeMembers(string homeId, User user);
    void UpdateNotificatedList(string homeId, string memberId);
    List<Device> GetHomeDevices(string homeId);
}
