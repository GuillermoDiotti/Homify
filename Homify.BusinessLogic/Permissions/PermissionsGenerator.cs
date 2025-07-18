﻿using Homify.BusinessLogic.Permissions.SystemPermissions.Entities;

namespace Homify.BusinessLogic.Permissions;

public static class PermissionsGenerator
{
    public const string CreateAdmin = "admins-Create";
    public const string DeleteAdmin = "admins-Delete";
    public const string GetAllAccounts = "admins-AllAccounts";
    public const string CreateCompanyOwner = "company-owners-Create";
    public const string GetCompanies = "homes-ObtainCompanies";

    public const string CreateCompany = "companies-Create";
    public const string RegisterCamera = "devices-RegisterCamera";
    public const string RegisterSensor = "companies-RegisterSensor";
    public const string RegisterLamp = "companies-RegisterLamp";
    public const string RegisterMovementSensor = "companies-RegisterMovementSensor";
    public const string ImportDevices = "companies-ImportDevices";

    public const string CreateHome = "homes-Create";
    public const string UpdateHomeMembersList = "homes-UpdateMembersList";
    public const string UpdateHomeDevices = "homes-UpdateHomeDevice";
    public const string GetHomeMembers = "homes-ObtainMembers";
    public const string GetHomeDevices = "homes-ObtainHomeDevices";
    public const string UpdateHomeNotificatedMembers = "homes-NotificatedMembers";
    public const string GetUserNotifications = "notifications-ObtainNotifications";
    public const string UpdateUserNotification = "notifications-UpdateNotification";

    public const string MemberCanAddDevice = "AddDevices";
    public const string MemberCanListDevices = "ListDevices";
    public const string MemberCanChangeNameDevices = "ChangeDeviceName";

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
            new(RegisterSensor),
            new(RegisterMovementSensor),
            new(RegisterLamp),
            new(ImportDevices)
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
