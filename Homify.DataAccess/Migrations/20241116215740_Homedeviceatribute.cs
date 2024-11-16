using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Homedeviceatribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3d78bc4d-c290-4f10-988d-c999f7c41968");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3f75eb6a-7c25-48ab-ac3b-fdf5eee89a4a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "462421d3-a8e9-471a-ae0c-6d20ad4957f7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4b4d60c5-8cec-4502-84bd-a549a5eee712");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "76ad731f-cedf-421a-aeff-cd537b31de77");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "76e39439-f269-4330-b2ca-7c8f65f2866a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "862400de-2a03-42f8-9dcf-5cb4ccc902df");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8f626bab-1735-4bf4-ad1c-64c848e789c8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9a413290-38fa-4ccc-9037-2cd3be151085");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b493214e-e975-4252-9ca6-0d189b8a23b1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b49dd05d-1e5d-43f5-b99a-452ae8a2cc8d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b5becc4b-1cc9-436b-977c-01207d8c34ee");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b60239c6-b440-4e5b-a464-1e86199ecd2e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b8a7ef55-3880-41d5-b116-123343dfc62a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c82217ec-3257-4b99-8edb-b943c6d2e9d8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e9fdde8e-98a8-4734-be36-39809e0c8211");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "0cf5473b-5f3a-4884-8db9-154a9989ae9f");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "36de09c2-4559-48b3-b772-b90f9f1055e6");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3f36062b-643b-4342-b924-9e59aeb9f209");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "03f50f6f-80f7-478d-9f1e-e4b557aeb49e", "9", "HomeOwnerId" },
                    { "44d1ec30-4dc3-43da-b22b-39571809b3bd", "1", "AdminId" },
                    { "50538feb-591c-4e89-a319-677dcee58259", "15", "HomeOwnerId" },
                    { "6c26a86c-284e-42b0-a2cb-cee3c5ea7ba2", "13", "HomeOwnerId" },
                    { "7cff6274-6e58-43de-9255-4b1ec52a0279", "12", "HomeOwnerId" },
                    { "823b328c-4267-4df3-9315-d2eb78985d50", "8", "CompanyOwnerId" },
                    { "829da6b7-0bd7-4c2a-871c-c93435205141", "5", "AdminId" },
                    { "94837bac-ec7d-4d68-880e-cad5abfdfee5", "10", "HomeOwnerId" },
                    { "95f1b3b8-4757-446b-a695-a6548220eb49", "11", "HomeOwnerId" },
                    { "b569de38-6dbb-4701-816d-c97fca1c8454", "4", "AdminId" },
                    { "c31e9772-5c27-4e04-abee-948fcabaa267", "3", "AdminId" },
                    { "dc4b7213-c714-49d4-938c-59e6308ef0b2", "16", "HomeOwnerId" },
                    { "dc97267a-2d6b-408a-9c8a-b62abb6bd4cc", "7", "CompanyOwnerId" },
                    { "f248b38b-e96a-4c3c-a36a-ffbb4a566df4", "2", "AdminId" },
                    { "f26ded1c-a924-495b-87d6-ef04f5a0e6b2", "14", "HomeOwnerId" },
                    { "fc36007b-3347-49cf-8b9d-79a80a36067b", "6", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7370855f-9ac1-4ca1-bacd-48463473f666", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "93372bb2-38d2-43c4-8cbb-a0ca79212645", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "dafb35a2-9e8f-448a-addc-37b134b6bfa6", "AdminId", "SeedAdminId" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "03f50f6f-80f7-478d-9f1e-e4b557aeb49e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "44d1ec30-4dc3-43da-b22b-39571809b3bd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "50538feb-591c-4e89-a319-677dcee58259");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6c26a86c-284e-42b0-a2cb-cee3c5ea7ba2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7cff6274-6e58-43de-9255-4b1ec52a0279");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "823b328c-4267-4df3-9315-d2eb78985d50");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "829da6b7-0bd7-4c2a-871c-c93435205141");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "94837bac-ec7d-4d68-880e-cad5abfdfee5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "95f1b3b8-4757-446b-a695-a6548220eb49");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b569de38-6dbb-4701-816d-c97fca1c8454");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c31e9772-5c27-4e04-abee-948fcabaa267");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "dc4b7213-c714-49d4-938c-59e6308ef0b2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "dc97267a-2d6b-408a-9c8a-b62abb6bd4cc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f248b38b-e96a-4c3c-a36a-ffbb4a566df4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f26ded1c-a924-495b-87d6-ef04f5a0e6b2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fc36007b-3347-49cf-8b9d-79a80a36067b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "7370855f-9ac1-4ca1-bacd-48463473f666");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "93372bb2-38d2-43c4-8cbb-a0ca79212645");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "dafb35a2-9e8f-448a-addc-37b134b6bfa6");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "3d78bc4d-c290-4f10-988d-c999f7c41968", "9", "HomeOwnerId" },
                    { "3f75eb6a-7c25-48ab-ac3b-fdf5eee89a4a", "6", "CompanyOwnerId" },
                    { "462421d3-a8e9-471a-ae0c-6d20ad4957f7", "16", "HomeOwnerId" },
                    { "4b4d60c5-8cec-4502-84bd-a549a5eee712", "3", "AdminId" },
                    { "76ad731f-cedf-421a-aeff-cd537b31de77", "11", "HomeOwnerId" },
                    { "76e39439-f269-4330-b2ca-7c8f65f2866a", "10", "HomeOwnerId" },
                    { "862400de-2a03-42f8-9dcf-5cb4ccc902df", "15", "HomeOwnerId" },
                    { "8f626bab-1735-4bf4-ad1c-64c848e789c8", "12", "HomeOwnerId" },
                    { "9a413290-38fa-4ccc-9037-2cd3be151085", "13", "HomeOwnerId" },
                    { "b493214e-e975-4252-9ca6-0d189b8a23b1", "7", "CompanyOwnerId" },
                    { "b49dd05d-1e5d-43f5-b99a-452ae8a2cc8d", "2", "AdminId" },
                    { "b5becc4b-1cc9-436b-977c-01207d8c34ee", "5", "AdminId" },
                    { "b60239c6-b440-4e5b-a464-1e86199ecd2e", "1", "AdminId" },
                    { "b8a7ef55-3880-41d5-b116-123343dfc62a", "8", "CompanyOwnerId" },
                    { "c82217ec-3257-4b99-8edb-b943c6d2e9d8", "4", "AdminId" },
                    { "e9fdde8e-98a8-4734-be36-39809e0c8211", "14", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0cf5473b-5f3a-4884-8db9-154a9989ae9f", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "36de09c2-4559-48b3-b772-b90f9f1055e6", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "3f36062b-643b-4342-b924-9e59aeb9f209", "AdminId", "SeedAdminId" }
                });
        }
    }
}
