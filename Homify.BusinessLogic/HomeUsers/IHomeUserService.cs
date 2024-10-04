namespace Homify.BusinessLogic.HomeUsers;

public interface IHomeUserService
{
    HomeUser? GetByIds(string? homeId, string? userId);
    HomeUser Update(HomeUser hu);
    List<HomeUser> GetHomeUsersByHomeId(string id);
}
