using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "1abef1e8-3897-46a1-b8dc-57b2ca743897");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "becaba6c-acf3-4043-b620-2db0fe9294cd");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "3b57d8d0-bc27-499f-a70b-e73d83e78555");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0301e944-6a8f-4c35-9e55-ee07dc299ca0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "136167a0-604e-47b3-9909-95ccadc86c40");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "390d18ae-1c2b-4486-908c-a541ed4e25dd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "40dfb2ef-eedd-4b60-98af-c8843f96f6ab");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5f619bbd-6ff3-4ffb-9377-6fabeae7fe13");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6468565a-edee-42c0-bd8e-9b300f2c540e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "935535b2-6e97-4428-8873-242405aaf9d7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "96ca72ba-17d0-4095-9142-d403e74f2061");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "99ba7126-78ff-4cc7-8cd2-08ca9ae435bf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "aeb89af6-60c0-4ded-b99f-e15a40b9435b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b8a5fcc0-6e97-4b0a-b593-00e35cd75d87");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c876a393-118f-44ab-9940-fce5c5ec9cc2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cb2110ff-2292-4c4e-8b3a-0f851e29aef1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d39dff6e-03c0-4ef6-afc1-81f2dc570775");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d8856241-f469-4c7f-a635-35dd08ee64bf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d986326a-629e-4f96-a7c0-50167a558c3f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ddb7c033-6eaa-425c-b544-c00d0931bbec");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f4092e9e-5a69-40a1-9354-631eed1f24e7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fcfdc999-3637-438d-87bb-4cd66d7ac325");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1abef1e8-3897-46a1-b8dc-57b2ca743897");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3b57d8d0-bc27-499f-a70b-e73d83e78555");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "becaba6c-acf3-4043-b620-2db0fe9294cd");

            migrationBuilder.AlterColumn<string>(
                name: "HardwareId",
                table: "HomeDevices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0525622a-bec3-4b81-aa09-5ccfa715dfcd", "6", "CompanyOwnerId" },
                    { "2507e45a-de6b-4a18-b694-dfd616753923", "1", "AdminId" },
                    { "2bf22b38-9130-4d11-8323-6c385a11a805", "2", "AdminId" },
                    { "2cdf07b7-3b54-4663-9fb3-461d15d3e11e", "19", "HomeOwnerId" },
                    { "3c049ff0-e02e-40c3-8bcc-fb0fb1a26d3b", "12", "HomeOwnerId" },
                    { "4546a0a4-54cf-4f0d-b30d-f6558a301722", "3", "AdminId" },
                    { "48599fce-c032-427d-8a07-000508a5e7a7", "16", "HomeOwnerId" },
                    { "533ff79e-cf7c-4c30-a903-da9950d127d6", "14", "HomeOwnerId" },
                    { "571c3f1b-21a7-4c63-84b0-7d636af34213", "15", "HomeOwnerId" },
                    { "57a8dd74-9e6a-437f-a792-5d63c2d85b6c", "8", "CompanyOwnerId" },
                    { "5be26469-1cb6-462b-bc18-ecab7bfdb48e", "18", "HomeOwnerId" },
                    { "6758993a-dd40-4568-b12e-27cbb7fb2aa1", "17", "HomeOwnerId" },
                    { "71a26694-4676-4189-ba29-512040252b89", "5", "AdminId" },
                    { "79c95d6e-7e8e-48f2-a978-a9f244b3c606", "4", "AdminId" },
                    { "8f6781ef-eea1-4bfb-883f-109332343ebb", "7", "CompanyOwnerId" },
                    { "a7d3f03d-57a3-4ce2-93a1-1b87baa1312b", "9", "HomeOwnerId" },
                    { "a916afb7-a203-4015-be03-f753c406508a", "11", "HomeOwnerId" },
                    { "cd76f4ab-485c-4d38-8444-784c4eafb58d", "13", "HomeOwnerId" },
                    { "f40fa0ec-dc11-48b3-bd6b-5a59afeef2a7", "10", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "79fdbfd4-10a0-49be-9746-8bfc6d999554", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 23, 21, 434, DateTimeKind.Unspecified).AddTicks(4591), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" },
                    { "9d1121ef-a732-4c1c-966f-66a8d43101c5", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 23, 21, 434, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" },
                    { "adde7479-c96e-4ae9-84c3-7345adb00049", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 23, 21, 434, DateTimeKind.Unspecified).AddTicks(4579), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "adde7479-c96e-4ae9-84c3-7345adb00049");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "9d1121ef-a732-4c1c-966f-66a8d43101c5", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "79fdbfd4-10a0-49be-9746-8bfc6d999554", "picture" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "adde7479-c96e-4ae9-84c3-7345adb00049");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "9d1121ef-a732-4c1c-966f-66a8d43101c5");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "79fdbfd4-10a0-49be-9746-8bfc6d999554");

            migrationBuilder.DeleteData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0525622a-bec3-4b81-aa09-5ccfa715dfcd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2507e45a-de6b-4a18-b694-dfd616753923");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2bf22b38-9130-4d11-8323-6c385a11a805");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2cdf07b7-3b54-4663-9fb3-461d15d3e11e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3c049ff0-e02e-40c3-8bcc-fb0fb1a26d3b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4546a0a4-54cf-4f0d-b30d-f6558a301722");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "48599fce-c032-427d-8a07-000508a5e7a7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "533ff79e-cf7c-4c30-a903-da9950d127d6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "571c3f1b-21a7-4c63-84b0-7d636af34213");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "57a8dd74-9e6a-437f-a792-5d63c2d85b6c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5be26469-1cb6-462b-bc18-ecab7bfdb48e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6758993a-dd40-4568-b12e-27cbb7fb2aa1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "71a26694-4676-4189-ba29-512040252b89");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "79c95d6e-7e8e-48f2-a978-a9f244b3c606");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8f6781ef-eea1-4bfb-883f-109332343ebb");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a7d3f03d-57a3-4ce2-93a1-1b87baa1312b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a916afb7-a203-4015-be03-f753c406508a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cd76f4ab-485c-4d38-8444-784c4eafb58d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f40fa0ec-dc11-48b3-bd6b-5a59afeef2a7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "79fdbfd4-10a0-49be-9746-8bfc6d999554");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9d1121ef-a732-4c1c-966f-66a8d43101c5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "adde7479-c96e-4ae9-84c3-7345adb00049");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareId",
                table: "HomeDevices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0301e944-6a8f-4c35-9e55-ee07dc299ca0", "3", "AdminId" },
                    { "136167a0-604e-47b3-9909-95ccadc86c40", "7", "CompanyOwnerId" },
                    { "390d18ae-1c2b-4486-908c-a541ed4e25dd", "1", "AdminId" },
                    { "40dfb2ef-eedd-4b60-98af-c8843f96f6ab", "12", "HomeOwnerId" },
                    { "5f619bbd-6ff3-4ffb-9377-6fabeae7fe13", "4", "AdminId" },
                    { "6468565a-edee-42c0-bd8e-9b300f2c540e", "16", "HomeOwnerId" },
                    { "935535b2-6e97-4428-8873-242405aaf9d7", "14", "HomeOwnerId" },
                    { "96ca72ba-17d0-4095-9142-d403e74f2061", "15", "HomeOwnerId" },
                    { "99ba7126-78ff-4cc7-8cd2-08ca9ae435bf", "19", "HomeOwnerId" },
                    { "aeb89af6-60c0-4ded-b99f-e15a40b9435b", "6", "CompanyOwnerId" },
                    { "b8a5fcc0-6e97-4b0a-b593-00e35cd75d87", "5", "AdminId" },
                    { "c876a393-118f-44ab-9940-fce5c5ec9cc2", "8", "CompanyOwnerId" },
                    { "cb2110ff-2292-4c4e-8b3a-0f851e29aef1", "17", "HomeOwnerId" },
                    { "d39dff6e-03c0-4ef6-afc1-81f2dc570775", "13", "HomeOwnerId" },
                    { "d8856241-f469-4c7f-a635-35dd08ee64bf", "18", "HomeOwnerId" },
                    { "d986326a-629e-4f96-a7c0-50167a558c3f", "11", "HomeOwnerId" },
                    { "ddb7c033-6eaa-425c-b544-c00d0931bbec", "10", "HomeOwnerId" },
                    { "f4092e9e-5a69-40a1-9354-631eed1f24e7", "9", "HomeOwnerId" },
                    { "fcfdc999-3637-438d-87bb-4cd66d7ac325", "2", "AdminId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "1abef1e8-3897-46a1-b8dc-57b2ca743897", new DateTimeOffset(new DateTime(2024, 10, 3, 15, 20, 34, 254, DateTimeKind.Unspecified).AddTicks(4600), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "3b57d8d0-bc27-499f-a70b-e73d83e78555", new DateTimeOffset(new DateTime(2024, 10, 3, 15, 20, 34, 254, DateTimeKind.Unspecified).AddTicks(4622), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" },
                    { "becaba6c-acf3-4043-b620-2db0fe9294cd", new DateTimeOffset(new DateTime(2024, 10, 3, 15, 20, 34, 254, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "1abef1e8-3897-46a1-b8dc-57b2ca743897");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "becaba6c-acf3-4043-b620-2db0fe9294cd", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "3b57d8d0-bc27-499f-a70b-e73d83e78555", "picture" });
        }
    }
}
