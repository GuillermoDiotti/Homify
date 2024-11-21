using Homify.BusinessLogic.HomeUsers.Entities;

namespace Homify.BusinessLogic.HomeUsers;

public interface IHomeUserService
{
    HomeUser? Get(string? homeId, string? userId);
    HomeUser Update(HomeUser hu);
    List<HomeUser> GetByHomeId(string id);
}
