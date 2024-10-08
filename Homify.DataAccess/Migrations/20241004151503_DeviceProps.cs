using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

[ExcludeFromCodeCoverage]

/// <inheritdoc />
public partial class DeviceProps : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0526b78f-ad8d-443d-9407-d9bb37638308");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1ceefa7d-893a-4eda-8715-fd60495f4282");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "246bb5c0-8ec7-4c2d-b874-261241fe2f79");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3008b79d-8ee5-4916-a8b0-1c3da94ea8d2");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "31bdf194-6731-4e17-b7ef-c279267e36b5");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3c35b3c1-4253-40f0-96c2-3d0ce0547258");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "469627d2-6a73-485e-881a-f43f25fa1a93");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5239e7a3-6b62-44ad-9251-a86f4ee50b6a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5bdc7199-d500-4abb-8494-3f156d08f5b0");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "62ba4927-c78b-441c-9693-a1059434433d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "68e712e4-b1bf-4121-9ecc-e880616afba6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "6f4d13cd-d21a-46d7-80a6-77f0977eb6eb");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7abee44d-8f9a-42f7-bfe1-2acfaec82cee");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "94363523-85bd-459e-b15a-6cc3658169de");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ba559d7d-5ee4-4f31-be7f-c7ff11b64618");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "e7596eec-daa7-4b31-8ea4-8f37c119c3bd");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ee7f22af-b2f4-4b13-81f8-7e42618fa02c");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "f0f3143d-baaa-4c46-9492-c0090537ee34");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "fad1f97e-8ebe-4f11-a3db-d921bebec031");

        migrationBuilder.DropColumn(
            name: "MovementDetection",
            table: "HomeDevices");

        migrationBuilder.DropColumn(
            name: "PeopleDetection",
            table: "HomeDevices");

        migrationBuilder.AddColumn<bool>(
            name: "MovementDetection",
            table: "Devices",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "PeopleDetection",
            table: "Devices",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "WindowDetection",
            table: "Devices",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "01802eeb-dd64-4641-9713-226464c5635e", "16", "HomeOwnerId" },
                { "01fc3f25-c78e-4909-ad05-f4932ac0fba8", "17", "HomeOwnerId" },
                { "2128e238-ed5b-4636-9036-53f9eef4a633", "10", "HomeOwnerId" },
                { "244a42a3-e639-405e-921d-4f915fe8372e", "12", "HomeOwnerId" },
                { "29feebf1-95d1-40f3-9d9c-b1665ee285ed", "18", "HomeOwnerId" },
                { "373c66dd-1fc6-4643-8745-730a0503f96f", "1", "AdminId" },
                { "39f77143-d084-408e-993f-7a8e7f5eda98", "3", "AdminId" },
                { "7f954dca-9016-4eb7-9965-eaafc394351a", "8", "CompanyOwnerId" },
                { "8b73e6ff-91e2-41f8-b511-74f9f5ce7943", "19", "HomeOwnerId" },
                { "997f12d1-34c1-4e64-ac77-063785a87dac", "2", "AdminId" },
                { "99d8d834-8b01-4892-aae8-67dd105ae36f", "6", "CompanyOwnerId" },
                { "ba7b5047-970f-4a8c-a99f-8a3203914442", "5", "AdminId" },
                { "bd6ef21d-bcac-4ff5-97f3-3b3045ff40ca", "7", "CompanyOwnerId" },
                { "c250e55e-77cb-40e6-b3fd-1364c6470d69", "4", "AdminId" },
                { "c404b72f-9eeb-4f84-b47e-ad6db9b51862", "15", "HomeOwnerId" },
                { "db625545-fda1-49c4-a40e-1705f6049c61", "14", "HomeOwnerId" },
                { "e18f1578-22d4-4d03-911e-7d301512aba1", "11", "HomeOwnerId" },
                { "fc74f1a2-3537-475d-89b3-0cb97dc535d4", "13", "HomeOwnerId" },
                { "ffa890ed-480c-4537-96b8-971335915cf3", "9", "HomeOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8659), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8675), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 15, 15, 2, 79, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 0, 0, 0, 0)));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "01802eeb-dd64-4641-9713-226464c5635e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "01fc3f25-c78e-4909-ad05-f4932ac0fba8");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2128e238-ed5b-4636-9036-53f9eef4a633");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "244a42a3-e639-405e-921d-4f915fe8372e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "29feebf1-95d1-40f3-9d9c-b1665ee285ed");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "373c66dd-1fc6-4643-8745-730a0503f96f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "39f77143-d084-408e-993f-7a8e7f5eda98");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7f954dca-9016-4eb7-9965-eaafc394351a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "8b73e6ff-91e2-41f8-b511-74f9f5ce7943");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "997f12d1-34c1-4e64-ac77-063785a87dac");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "99d8d834-8b01-4892-aae8-67dd105ae36f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ba7b5047-970f-4a8c-a99f-8a3203914442");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "bd6ef21d-bcac-4ff5-97f3-3b3045ff40ca");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c250e55e-77cb-40e6-b3fd-1364c6470d69");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c404b72f-9eeb-4f84-b47e-ad6db9b51862");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "db625545-fda1-49c4-a40e-1705f6049c61");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "e18f1578-22d4-4d03-911e-7d301512aba1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "fc74f1a2-3537-475d-89b3-0cb97dc535d4");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ffa890ed-480c-4537-96b8-971335915cf3");

        migrationBuilder.DropColumn(
            name: "MovementDetection",
            table: "Devices");

        migrationBuilder.DropColumn(
            name: "PeopleDetection",
            table: "Devices");

        migrationBuilder.DropColumn(
            name: "WindowDetection",
            table: "Devices");

        migrationBuilder.AddColumn<bool>(
            name: "MovementDetection",
            table: "HomeDevices",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "PeopleDetection",
            table: "HomeDevices",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "0526b78f-ad8d-443d-9407-d9bb37638308", "1", "AdminId" },
                { "1ceefa7d-893a-4eda-8715-fd60495f4282", "19", "HomeOwnerId" },
                { "246bb5c0-8ec7-4c2d-b874-261241fe2f79", "3", "AdminId" },
                { "3008b79d-8ee5-4916-a8b0-1c3da94ea8d2", "18", "HomeOwnerId" },
                { "31bdf194-6731-4e17-b7ef-c279267e36b5", "14", "HomeOwnerId" },
                { "3c35b3c1-4253-40f0-96c2-3d0ce0547258", "12", "HomeOwnerId" },
                { "469627d2-6a73-485e-881a-f43f25fa1a93", "5", "AdminId" },
                { "5239e7a3-6b62-44ad-9251-a86f4ee50b6a", "17", "HomeOwnerId" },
                { "5bdc7199-d500-4abb-8494-3f156d08f5b0", "11", "HomeOwnerId" },
                { "62ba4927-c78b-441c-9693-a1059434433d", "2", "AdminId" },
                { "68e712e4-b1bf-4121-9ecc-e880616afba6", "9", "HomeOwnerId" },
                { "6f4d13cd-d21a-46d7-80a6-77f0977eb6eb", "7", "CompanyOwnerId" },
                { "7abee44d-8f9a-42f7-bfe1-2acfaec82cee", "16", "HomeOwnerId" },
                { "94363523-85bd-459e-b15a-6cc3658169de", "13", "HomeOwnerId" },
                { "ba559d7d-5ee4-4f31-be7f-c7ff11b64618", "15", "HomeOwnerId" },
                { "e7596eec-daa7-4b31-8ea4-8f37c119c3bd", "6", "CompanyOwnerId" },
                { "ee7f22af-b2f4-4b13-81f8-7e42618fa02c", "8", "CompanyOwnerId" },
                { "f0f3143d-baaa-4c46-9492-c0090537ee34", "4", "AdminId" },
                { "fad1f97e-8ebe-4f11-a3db-d921bebec031", "10", "HomeOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 14, 37, 10, 817, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 14, 37, 10, 817, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 14, 37, 10, 817, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 0, 0, 0, 0)));
    }
}
