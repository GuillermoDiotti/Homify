using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "11cac00e-08b6-4787-a75e-771527609aa6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "22ee2841-cb66-4ba0-8414-717b70fe9a88");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "27997433-e84c-4c99-b2c8-cce2fb4647fa");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2cf74557-b66b-475a-ab38-95ce313c62bc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "30e1723b-7649-429b-82b2-2fd2ec70dec2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "441e9fc3-a436-48b1-99a7-9d9419993ff8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "483f51c3-d4c0-4404-8161-7c4d0946ffd1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "48cd7cbb-789f-4d1a-a3c2-f713c71a4584");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4a529e00-8985-4d80-a458-9bd9d7360dcd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "92a5e3bd-dba5-49f3-bc52-56a44605fba6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "937d4e3b-4d46-4af0-8d76-fe732cca357b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "97b276f3-8fa4-448d-a4d2-7fc10b616069");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a69cc11e-0c29-4712-a30e-dacb11cb59ff");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b1f25b0d-1ca0-4da0-8310-5293d62bd187");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bef0ff6e-0aff-4bfc-9997-d8872dcdcca0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c1212017-7f21-4309-85fa-37c92255a7cb");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e5defa4d-8a49-4b1a-aa1d-25795aecc9aa");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e7595eb5-16c6-4b7c-9fef-c62ed0f95977");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f0be094e-0ed5-45e9-96db-fcaf502d1ae4");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "HomeOwners");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "CreatedAt", "ProfilePicture" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                columns: new[] { "CreatedAt", "ProfilePicture" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6384), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                columns: new[] { "CreatedAt", "ProfilePicture" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 4, 1, 45, 2, 872, DateTimeKind.Unspecified).AddTicks(6378), new TimeSpan(0, 0, 0, 0, 0)), "picture" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "HomeOwners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.UpdateData(
                table: "HomeOwners",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "ProfilePicture",
                value: "picture");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "11cac00e-08b6-4787-a75e-771527609aa6", "11", "HomeOwnerId" },
                    { "22ee2841-cb66-4ba0-8414-717b70fe9a88", "6", "CompanyOwnerId" },
                    { "27997433-e84c-4c99-b2c8-cce2fb4647fa", "3", "AdminId" },
                    { "2cf74557-b66b-475a-ab38-95ce313c62bc", "13", "HomeOwnerId" },
                    { "30e1723b-7649-429b-82b2-2fd2ec70dec2", "16", "HomeOwnerId" },
                    { "441e9fc3-a436-48b1-99a7-9d9419993ff8", "19", "HomeOwnerId" },
                    { "483f51c3-d4c0-4404-8161-7c4d0946ffd1", "14", "HomeOwnerId" },
                    { "48cd7cbb-789f-4d1a-a3c2-f713c71a4584", "17", "HomeOwnerId" },
                    { "4a529e00-8985-4d80-a458-9bd9d7360dcd", "7", "CompanyOwnerId" },
                    { "92a5e3bd-dba5-49f3-bc52-56a44605fba6", "8", "CompanyOwnerId" },
                    { "937d4e3b-4d46-4af0-8d76-fe732cca357b", "4", "AdminId" },
                    { "97b276f3-8fa4-448d-a4d2-7fc10b616069", "1", "AdminId" },
                    { "a69cc11e-0c29-4712-a30e-dacb11cb59ff", "18", "HomeOwnerId" },
                    { "b1f25b0d-1ca0-4da0-8310-5293d62bd187", "5", "AdminId" },
                    { "bef0ff6e-0aff-4bfc-9997-d8872dcdcca0", "2", "AdminId" },
                    { "c1212017-7f21-4309-85fa-37c92255a7cb", "9", "HomeOwnerId" },
                    { "e5defa4d-8a49-4b1a-aa1d-25795aecc9aa", "15", "HomeOwnerId" },
                    { "e7595eb5-16c6-4b7c-9fef-c62ed0f95977", "10", "HomeOwnerId" },
                    { "f0be094e-0ed5-45e9-96db-fcaf502d1ae4", "12", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3660), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3682), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 10, 4, 0, 17, 4, 70, DateTimeKind.Unspecified).AddTicks(3671), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
