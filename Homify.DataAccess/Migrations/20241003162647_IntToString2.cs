using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntToString2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "11df4adb-3217-4494-ac4e-b552349ef602", "4", "AdminId" },
                    { "22521359-23f0-4e17-ac05-cedd466c3ab4", "10", "HomeOwnerId" },
                    { "2864b2e5-620d-4826-a270-4452e595a110", "7", "CompanyOwnerId" },
                    { "3685181c-78a5-4509-8ed0-85417737e33c", "11", "HomeOwnerId" },
                    { "405e2053-c373-464b-b5d2-4e47104c1251", "19", "HomeOwnerId" },
                    { "4358ab65-3ac5-4d4a-a8c4-fc9e381790dd", "3", "AdminId" },
                    { "5e560913-3c29-4ea4-9c0a-7ef203a35f75", "8", "CompanyOwnerId" },
                    { "887c5e3e-121c-48ab-936a-ae660d1287c3", "15", "HomeOwnerId" },
                    { "93cc90d9-9a6f-4845-b7aa-a266a105e7f9", "13", "HomeOwnerId" },
                    { "ab78e16e-b4e8-498f-a5eb-1e07e66f0079", "18", "HomeOwnerId" },
                    { "b75a367f-4b18-4f38-b5b5-d7cf29f11082", "9", "HomeOwnerId" },
                    { "cb433c65-efd6-4151-bb70-4c5d5d940d39", "1", "AdminId" },
                    { "cfbbd4fd-91a2-4e4b-9f8f-81a1f5a69cd3", "16", "HomeOwnerId" },
                    { "d64b42cc-8473-436d-87e3-b51a24f3a594", "12", "HomeOwnerId" },
                    { "e49ddb85-313b-40a7-899f-e6ca171176e5", "17", "HomeOwnerId" },
                    { "e52271f4-1eea-47d0-b8c0-edf9ac84caaf", "6", "CompanyOwnerId" },
                    { "f4aa1354-f6d7-4dc2-9429-b335c29e29fe", "5", "AdminId" },
                    { "f86194d4-819b-4d55-a4b9-8af6b8551e9e", "14", "HomeOwnerId" },
                    { "f8b7f016-ce69-463d-9dd9-7fd2f19cb8bd", "2", "AdminId" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { "44346f94-7612-43d1-bec7-e03c4789c569", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 26, 46, 944, DateTimeKind.Unspecified).AddTicks(4188), new TimeSpan(0, 0, 0, 0, 0)), "admin@domain.com", "LastName", "Admin", ".Popso212", "AdminId" },
                    { "b11f22b2-c507-40f5-83d3-e2ab904bb21b", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 26, 46, 944, DateTimeKind.Unspecified).AddTicks(4215), new TimeSpan(0, 0, 0, 0, 0)), "companyowner@domain.com", "LastName", "CompanyOwner", ".Popso212", "CompanyOwnerId" },
                    { "c89c8736-45e4-46e8-a752-45be075b3fda", new DateTimeOffset(new DateTime(2024, 10, 3, 16, 26, 46, 944, DateTimeKind.Unspecified).AddTicks(4203), new TimeSpan(0, 0, 0, 0, 0)), "homeowner@domain.com", "LastName", "Homeowner", ".Popso212", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: "44346f94-7612-43d1-bec7-e03c4789c569");

            migrationBuilder.InsertData(
                table: "CompanyOwners",
                columns: new[] { "Id", "IsIncomplete" },
                values: new object[] { "b11f22b2-c507-40f5-83d3-e2ab904bb21b", true });

            migrationBuilder.InsertData(
                table: "HomeOwners",
                columns: new[] { "Id", "ProfilePicture" },
                values: new object[] { "c89c8736-45e4-46e8-a752-45be075b3fda", "picture" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "44346f94-7612-43d1-bec7-e03c4789c569");

            migrationBuilder.DeleteData(
                table: "CompanyOwners",
                keyColumn: "Id",
                keyValue: "b11f22b2-c507-40f5-83d3-e2ab904bb21b");

            migrationBuilder.DeleteData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "c89c8736-45e4-46e8-a752-45be075b3fda");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "11df4adb-3217-4494-ac4e-b552349ef602");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "22521359-23f0-4e17-ac05-cedd466c3ab4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2864b2e5-620d-4826-a270-4452e595a110");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3685181c-78a5-4509-8ed0-85417737e33c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "405e2053-c373-464b-b5d2-4e47104c1251");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4358ab65-3ac5-4d4a-a8c4-fc9e381790dd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5e560913-3c29-4ea4-9c0a-7ef203a35f75");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "887c5e3e-121c-48ab-936a-ae660d1287c3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "93cc90d9-9a6f-4845-b7aa-a266a105e7f9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ab78e16e-b4e8-498f-a5eb-1e07e66f0079");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b75a367f-4b18-4f38-b5b5-d7cf29f11082");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cb433c65-efd6-4151-bb70-4c5d5d940d39");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cfbbd4fd-91a2-4e4b-9f8f-81a1f5a69cd3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d64b42cc-8473-436d-87e3-b51a24f3a594");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e49ddb85-313b-40a7-899f-e6ca171176e5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e52271f4-1eea-47d0-b8c0-edf9ac84caaf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f4aa1354-f6d7-4dc2-9429-b335c29e29fe");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f86194d4-819b-4d55-a4b9-8af6b8551e9e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f8b7f016-ce69-463d-9dd9-7fd2f19cb8bd");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "44346f94-7612-43d1-bec7-e03c4789c569");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b11f22b2-c507-40f5-83d3-e2ab904bb21b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c89c8736-45e4-46e8-a752-45be075b3fda");

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
    }
}
