using Homify.BusinessLogic.HomeUsers;

namespace Homify.BusinessLogic.Homes.Entities;
public class HomePermission
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public HomeUser HomeUser { get; set; } = null!;
    public string HomeId { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
