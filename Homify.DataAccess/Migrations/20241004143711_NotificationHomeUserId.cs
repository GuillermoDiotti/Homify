using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

[ExcludeFromCodeCoverage]

/// <inheritdoc />
public partial class NotificationHomeUserId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2347207f-003a-4916-b8e4-c4339519ae4f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "24291b09-1f60-46ed-aa1b-e8c285563374");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "252f6387-0334-419e-9746-2630f494e48e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3454ac5f-5199-4f86-b4ab-4af92e64bb1d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3dc8dc23-e298-409a-99aa-0bdc9d7e12a1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "57ea2fa8-dd2f-47db-9557-7baaa5285272");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "68688c4a-66cb-4ab2-87f8-247633a60e3d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "76f816ed-76f9-4fa0-bbf1-505aeac5712d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "78515c4f-76a7-4c1b-b091-8a7da3ff30da");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "925b9f11-d3cd-40c3-8551-2f79ffa6d414");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "980c097c-f124-489f-8e45-ae4086c4a7e3");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a07e069b-0cf6-4677-bcb3-06eb72468a5a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "afb05781-c371-4011-b73c-6584befb1632");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b2e4e4fe-8098-48fd-8afa-c4e62a19830c");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "bbc69768-b52b-4e07-9dd9-8b17302dbbf2");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c59bcc88-609a-4e0c-b18d-75d55a2a08bb");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c897d4d7-81e1-4a3f-b957-db408077a7f1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "dd54b437-84e9-4312-8d0d-83bf06025207");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "fa6dd452-e369-4344-9e09-b67d452ae563");

        migrationBuilder.AddColumn<string>(
            name: "DetectedUserId",
            table: "Notifications",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "HomeUserId",
            table: "Notifications",
            type: "nvarchar(450)",
            nullable: true);

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

        migrationBuilder.CreateIndex(
            name: "IX_Notifications_HomeUserId",
            table: "Notifications",
            column: "HomeUserId");

        migrationBuilder.AddForeignKey(
            name: "FK_Notifications_HomeUsers_HomeUserId",
            table: "Notifications",
            column: "HomeUserId",
            principalTable: "HomeUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Notifications_HomeUsers_HomeUserId",
            table: "Notifications");

        migrationBuilder.DropIndex(
            name: "IX_Notifications_HomeUserId",
            table: "Notifications");

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
            name: "DetectedUserId",
            table: "Notifications");

        migrationBuilder.DropColumn(
            name: "HomeUserId",
            table: "Notifications");

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "2347207f-003a-4916-b8e4-c4339519ae4f", "1", "AdminId" },
                { "24291b09-1f60-46ed-aa1b-e8c285563374", "15", "HomeOwnerId" },
                { "252f6387-0334-419e-9746-2630f494e48e", "7", "CompanyOwnerId" },
                { "3454ac5f-5199-4f86-b4ab-4af92e64bb1d", "13", "HomeOwnerId" },
                { "3dc8dc23-e298-409a-99aa-0bdc9d7e12a1", "16", "HomeOwnerId" },
                { "57ea2fa8-dd2f-47db-9557-7baaa5285272", "6", "CompanyOwnerId" },
                { "68688c4a-66cb-4ab2-87f8-247633a60e3d", "5", "AdminId" },
                { "76f816ed-76f9-4fa0-bbf1-505aeac5712d", "2", "AdminId" },
                { "78515c4f-76a7-4c1b-b091-8a7da3ff30da", "19", "HomeOwnerId" },
                { "925b9f11-d3cd-40c3-8551-2f79ffa6d414", "11", "HomeOwnerId" },
                { "980c097c-f124-489f-8e45-ae4086c4a7e3", "10", "HomeOwnerId" },
                { "a07e069b-0cf6-4677-bcb3-06eb72468a5a", "3", "AdminId" },
                { "afb05781-c371-4011-b73c-6584befb1632", "17", "HomeOwnerId" },
                { "b2e4e4fe-8098-48fd-8afa-c4e62a19830c", "9", "HomeOwnerId" },
                { "bbc69768-b52b-4e07-9dd9-8b17302dbbf2", "12", "HomeOwnerId" },
                { "c59bcc88-609a-4e0c-b18d-75d55a2a08bb", "14", "HomeOwnerId" },
                { "c897d4d7-81e1-4a3f-b957-db408077a7f1", "4", "AdminId" },
                { "dd54b437-84e9-4312-8d0d-83bf06025207", "18", "HomeOwnerId" },
                { "fa6dd452-e369-4344-9e09-b67d452ae563", "8", "CompanyOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 13, 49, 44, 453, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 13, 49, 44, 453, DateTimeKind.Unspecified).AddTicks(2112), new TimeSpan(0, 0, 0, 0, 0)));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: new DateTimeOffset(new DateTime(2024, 10, 4, 13, 49, 44, 453, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 0, 0, 0, 0)));
    }
}
