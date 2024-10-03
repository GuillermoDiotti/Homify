using Homify.BusinessLogic.HomeUsers;

namespace Homify.BusinessLogic.Homes.Entities;
public class HomePermission
{
    public string Id { get; set; } = null!;
    public string Value { get; set; } = null!;
    public HomeUser HomeUser { get; set; } = null!;
    public string HomeId { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
