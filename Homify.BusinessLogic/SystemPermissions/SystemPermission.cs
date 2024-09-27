namespace Homify.BusinessLogic.SystemPermissions;

public class SystemPermission
{
    public string? Value { get; set; }

    public SystemPermission(string value)
    {
        Value = value;
    }

    public SystemPermission()
    {
    }
}
