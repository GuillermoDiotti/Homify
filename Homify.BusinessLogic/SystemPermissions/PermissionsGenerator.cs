namespace Homify.BusinessLogic.SystemPermissions;

public static class PermissionsGenerator
{
    // ADMIN PERMISSIONS
    public static string CreateAdmin { get; } = "admins-Create";
    public static string DeleteAdmin { get; } = "admins-Delete";
    public static string GetAllAccounts { get; } = "admins-AllAccounts";
    public static string CreateCompanyOwner { get; } = "company-owners-Create";
    public static string GetCompanies { get; } = "homes-ObtainCompanies";

    // COMPANY OWNER PERMISSIONS
    public static string CreateCompany { get; } = "companies-Create";
    public static string RegisterCamera { get; } = "devices-RegisterCamera";
    public static string RegisterSensor { get; } = "companies-RegisterSensor";

    // HOME OWNER PERMISSIONS
    public static string CreateHome { get; } = "homes-Create";
    public static string UpdateHomeMembersList { get; } = "homes-UpdateMembersList";
    public static string UpdateHomeDevices { get; } = "homes-UpdateHomeDevice";
    public static string GetHomeMembers { get; } = "homes-ObtainMembers";
    public static string GetHomeDevices { get; } = "homes-ObtainHomeDevices";
    public static string UpdateHomeNotificatedMembers { get; } = "homes-NotificatedMembers";
    public static string GetUserNotifications { get; } = "notifications-ObtainNotifications";
    public static string UpdateUserNotification { get; } = "notifications-UpdateNotification";

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
