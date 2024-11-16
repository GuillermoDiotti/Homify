namespace Homify.BusinessLogic.HomeUsers;

public interface IHomeUserService
{
    HomeUser? GetHomeUser(string? homeId, string? userId);
    HomeUser Update(HomeUser hu);
    List<HomeUser> GetHomeUsersByHomeId(string id);
}
