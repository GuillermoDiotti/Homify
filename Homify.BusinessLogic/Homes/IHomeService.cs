using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
    Home? GetHomeById(string id);
    Home AddMemberToHome(string homeId, string userMail);
    HomeDevice AssignDeviceToHome(string deviceid, string homeid, User user);
    List<HomeUser> GetHomeMembers(string homeId, User user);
    List<HomeUser> UpdateNotificatedList(string homeId, string memberId, User owner);
    List<HomeDevice> GetHomeDevices(string? homeId, User u);
    Home UpdateHome(string homeId, string? alias, User u);
    List<Home> GetAllHomesWhereUserIsOwner(User user);
    List<Home> GetAllHomesWhereUserIsMember(User user);
}
