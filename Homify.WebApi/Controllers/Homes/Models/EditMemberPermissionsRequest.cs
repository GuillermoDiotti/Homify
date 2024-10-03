namespace Homify.WebApi.Controllers.Homes.Models;

public class EditMemberPermissionsRequest
{
    public bool CanAddDevices { get; set; }
    public bool CanListDevices { get; set; }
}
