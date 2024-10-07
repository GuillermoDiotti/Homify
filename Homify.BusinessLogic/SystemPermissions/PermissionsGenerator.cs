using Homify.BusinessLogic.SystemPermissions;

public static class PermissionsGenerator
{
    // ADMIN PERMISSIONS
    public const string CreateAdmin = "admins-Create";
    public const string DeleteAdmin = "admins-Delete";
    public const string GetAllAccounts = "admins-AllAccounts";
    public const string CreateCompanyOwner = "company-owners-Create";
    public const string GetCompanies = "homes-ObtainCompanies";

    // COMPANY OWNER PERMISSIONS
    public const string CreateCompany = "companies-Create";
    public const string RegisterCamera = "devices-RegisterCamera";
    public const string RegisterSensor = "companies-RegisterSensor";

    // HOME OWNER PERMISSIONS
    public const string CreateHome = "homes-Create";
    public const string UpdateHomeMembersList = "homes-UpdateMembersList";
    public const string UpdateHomeDevices = "homes-UpdateHomeDevice";
    public const string GetHomeMembers = "homes-ObtainMembers";
    public const string GetHomeDevices = "homes-ObtainHomeDevices";
    public const string UpdateHomeNotificatedMembers = "homes-NotificatedMembers";
    public const string GetUserNotifications = "notifications-ObtainNotifications";
    public const string UpdateUserNotification = "notifications-UpdateNotification";

    // NON AUTHENTICATED USER
    public const string ViewRegisteredDevices = "devices-ViewRegistered";
    public const string ViewSupportedDevices = "companies-ViewSupported";

    // ???
    public const string CreateNotification = "notifications-Create";

    // HOMEUSERS
    public const string MemberCanAddDevice = "AddDevices";
    public const string MemberCanListDevices = "ListDevices";

    public static List<SystemPermission> GetAdminPermissions()
    {
        List<SystemPermission> permissions =
        [
            new(CreateAdmin),
            new(DeleteAdmin),
            new(GetAllAccounts),
            new(CreateCompanyOwner),
            new(GetCompanies)
        ];
        return permissions;
    }

    public static List<SystemPermission> GetCompanyOwnerPermissions()
    {
        List<SystemPermission> permissions =
        [
            new(CreateCompany),
            new(RegisterCamera),
            new(RegisterSensor)
        ];
        return permissions;
    }

    public static List<SystemPermission> GetHomeOwnerPermissions()
    {
        List<SystemPermission> permissions =
        [
            new(CreateHome),
            new(UpdateHomeMembersList),
            new(UpdateHomeDevices),
            new(GetHomeMembers),
            new(GetHomeDevices),
            new(UpdateHomeNotificatedMembers),
            new(GetUserNotifications),
            new(UpdateUserNotification)
        ];
        return permissions;
    }
}
