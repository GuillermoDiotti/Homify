using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home AddHome(CreateHomeArgs home);
    Home? GetHomeById(string id);
    Home UpdateMemberList(string homeId, string userMail);
    HomeDevice UpdateHomeDevices(string deviceid, string homeid, User user);
    List<HomeUser> GetHomeMembers(string homeId, User user);
    List<HomeUser> UpdateNotificatedList(string homeId, string memberId, User owner);
    List<HomeDevice> GetHomeDevices(string homeId, User u);
    Home UpdateHome(string homeId, string? alias, User u);
    List<Home> GetAllHomes(User user);
}
