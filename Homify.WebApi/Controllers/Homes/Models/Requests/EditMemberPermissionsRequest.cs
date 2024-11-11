namespace Homify.WebApi.Controllers.Homes.Models.Requests;

public class EditMemberPermissionsRequest
{
    public bool CanAddDevices { get; set; }
    public bool CanListDevices { get; set; }
    public bool CanRenameDevices { get; set; }
}
