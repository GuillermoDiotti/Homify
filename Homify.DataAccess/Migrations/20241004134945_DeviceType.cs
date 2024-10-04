using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeviceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "045be885-a4e2-4abd-99ef-29dfe7fd030a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0d557d77-3479-4915-bac4-c920549c1ad6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "15e15725-1453-4cc1-8320-b8411bc50606");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4fec49e1-0d96-4dbc-8ae6-da1d53eeef18");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5f027ea1-a219-4078-b6de-b1ba4a18571f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "64de4eee-a6a9-4dda-b148-527d79190dde");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7f6f61f0-569a-42d6-9b43-50d63efbbcae");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "84c56184-812e-4765-8617-2c02dbf6c86c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8888d38f-7962-4f10-ab4f-863167943a93");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9cf86e59-247a-464d-b4bb-99a6c7ce6ea1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ad7c5dca-d227-4dea-a640-21dd1b9bfd52");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b34964a5-ce9b-4c97-a91a-e39e33c81ed7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c227b033-3940-4ad7-a835-3ad98cc1cf2f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c2feb0b4-57dc-4522-9f50-5b8f3183a99f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0c208cc-c217-4e31-ab7d-7ff959099b10");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e01cfa54-9757-42b3-8880-87f012790eff");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e65edf15-80d7-4ea7-a83d-59f48b2e8355");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ebbb435b-6269-4319-b3fa-a832d780c7a0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fb601490-a662-4860-8018-474dbc5d15dd");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "045be885-a4e2-4abd-99ef-29dfe7fd030a", "1", "AdminId" },
                    { "0d557d77-3479-4915-bac4-c920549c1ad6", "13", "HomeOwnerId" },
                    { "15e15725-1453-4cc1-8320-b8411bc50606", "6", "CompanyOwnerId" },
                    { "4fec49e1-0d96-4dbc-8ae6-da1d53eeef18", "12", "HomeOwnerId" },
                    { "5f027ea1-a219-4078-b6de-b1ba4a18571f", "18", "HomeOwnerId" },
                    { "64de4eee-a6a9-4dda-b148-527d79190dde", "9", "HomeOwnerId" },
                    { "7f6f61f0-569a-42d6-9b43-50d63efbbcae", "10", "HomeOwnerId" },
                    { "84c56184-812e-4765-8617-2c02dbf6c86c", "14", "HomeOwnerId" },
                    { "8888d38f-7962-4f10-ab4f-863167943a93", "7", "CompanyOwnerId" },
                    { "9cf86e59-247a-464d-b4bb-99a6c7ce6ea1", "4", "AdminId" },
                    { "ad7c5dca-d227-4dea-a640-21dd1b9bfd52", "15", "HomeOwnerId" },
                    { "b34964a5-ce9b-4c97-a91a-e39e33c81ed7", "2", "AdminId" },
                    { "c227b033-3940-4ad7-a835-3ad98cc1cf2f", "17", "HomeOwnerId" },
                    { "c2feb0b4-57dc-4522-9f50-5b8f3183a99f", "5", "AdminId" },
                    { "d0c208cc-c217-4e31-ab7d-7ff959099b10", "19", "HomeOwnerId" },
                    { "e01cfa54-9757-42b3-8880-87f012790eff", "16", "HomeOwnerId" },
                    { "e65edf15-80d7-4ea7-a83d-59f48b2e8355", "8", "CompanyOwnerId" },
                    { "ebbb435b-6269-4319-b3fa-a832d780c7a0", "3", "AdminId" },
                    { "fb601490-a662-4860-8018-474dbc5d15dd", "11", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
