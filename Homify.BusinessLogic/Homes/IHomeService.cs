using Homify.BusinessLogic.HomeDevices.Entities;
using Homify.BusinessLogic.Homes.Entities;
using Homify.BusinessLogic.HomeUsers.Entities;
using Homify.BusinessLogic.Users.Entities;

namespace Homify.BusinessLogic.Homes;
public interface IHomeService
{
    Home Add(CreateHomeArgs home);
    Home? GetById(string id);
    Home AddMember(string homeId, string userMail);
    HomeDevice AssignDevice(string deviceid, string homeid, User user);
    List<HomeUser> GetMembers(string homeId, User user);
    List<HomeUser> UpdateNotificatedList(string homeId, string memberId, User owner);
    List<HomeDevice> GetHomeDevices(string? homeId, User u);
    Home Update(string homeId, string? alias, User u);
    List<Home> GetAllWhereUserIsOwner(User user);
    List<Home> GetAllWhereUserIsMember(User user);
}
