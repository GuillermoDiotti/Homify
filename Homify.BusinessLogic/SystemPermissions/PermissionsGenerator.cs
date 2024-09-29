namespace Homify.BusinessLogic.SystemPermissions;

public static class PermissionsGenerator
{
    // ADMIN PERMISSIONS
    private static string CreateAdmin { get; } = "admins-Create";
    private static string DeleteAdmin { get; } = "admins-Delete";
    private static string GetAllAccounts { get; } = "admins-AllAccounts";
    private static string CreateCompanyOwner { get; } = "company-owners-Create";
    private static string GetCompanies { get; } = "homes-ObtainCompanies";

    // COMPANY OWNER PERMISSIONS
    private static string CreateCompany { get; } = "companies-Create";
    private static string RegisterCamera { get; } = "devices-RegisterCamera";
    private static string RegisterSensor { get; } = "companies-RegisterSensor";

    // HOME OWNER PERMISSIONS
    private static string CreateHome { get; } = "homes-Create";
    private static string UpdateHomeMembersList { get; } = "homes-UpdateMembersList";
    private static string UpdateHomeDevices { get; } = "homes-UpdateHomeDevice";
    private static string GetHomeMembers { get; } = "homes-ObtainMembers";
    private static string GetHomeDevices { get; } = "homes-ObtainHomeDevices";
    private static string UpdateHomeNotificatedMembers { get; } = "homes-NotificatedMembers";
    private static string GetUserNotifications { get; } = "notifications-ObtainNotifications";
    private static string UpdateUserNotification { get; } = "notifications-UpdateNotification";

    // NON AUTHENTICATED USER
    public static string ViewRegisteredDevices { get; } = "devices-ViewRegistered";
    public static string ViewSupportedDevices { get; } = "companies-ViewSupported";

    // ???
    public static string CreateNotification { get; } = "notifications-Create";

    public static List<SystemPermission> GetAdminPermissions()
    {
        List<SystemPermission> permissions =
        [
            new(CreateAdmin),
            new(DeleteAdmin),
            new(GetAllAccounts),
            new(CreateCompanyOwner),
            new(GetCompanies),
        ];
        return permissions;
    }

    public static List<SystemPermission> GetCompanyOwnerPermissions()
    {
        var permission1 = new SystemPermission()
        {
            Value = CreateCompany,
        };
        var permission2 = new SystemPermission()
        {
            Value = RegisterCamera,
        };
        var permission3 = new SystemPermission()
        {
            Value = RegisterSensor,
        };
        List<SystemPermission> permissions =
        [
            permission1,
            permission2,
            permission3,
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
            new(UpdateUserNotification),
        ];
        return permissions;
    }
}
