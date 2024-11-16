using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Merge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "01a0adae-ebfb-4db6-82f6-97a025e65129");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "04b8ad0f-ae0d-499d-b7de-74202a3075ca");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0b94b21f-bf71-435e-89a7-2650cca804df");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "19e48745-0286-4420-9c54-1bce5f49474c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2d8f9b1a-af97-4232-8823-12da6ccc97f3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2f1baa39-9d85-4f97-a784-3b539a1c0926");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "352ac4a4-625f-461d-9c99-b01f9c2bf2c9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "428af407-49c7-4e1d-a4fc-77d8b94a0de9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5409905b-baf6-414f-965d-daa7c12f695f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "69bdb010-d551-4ed3-a6f7-b3e68ca2a218");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8593e115-8f4a-4c15-9ea6-0f3df404ffac");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8afec07e-d111-4d68-956f-b03aab696ad0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8d771326-124a-472f-8d86-12399b3d7ff6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a4963d93-98fc-4187-a2fc-69f2cd93efee");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b5384b1b-c938-4275-8f43-bf0b32b5d3e5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bf494d18-0d54-423a-babb-4b3451c6c914");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c3b39c02-ddd0-4ae5-8b59-b9e6d2054fe0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c740ac07-32c8-41aa-b390-dea6031d6038");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0d568c3-765e-4b3b-a894-6835cba94c51");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "9e6badb2-186c-4e92-8092-7e156e98662d");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "b9759989-034f-4824-8f4b-ac7ded2ec4a7");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "eecb396a-9b8d-4d8b-98ae-edb3b0134de4");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "074f6f7f-fbc9-4c0e-84b0-4d6a52f783d4", "15", "HomeOwnerId" },
                    { "0b78b415-3078-403a-95e3-d8f229b65cd1", "12", "HomeOwnerId" },
                    { "0dbe6875-a4b7-4b3c-8a9d-74c0a88448df", "11", "HomeOwnerId" },
                    { "0f96f5f3-5d24-436b-a818-be9bcea73f1b", "9", "HomeOwnerId" },
                    { "369f428b-fd14-4056-a671-9acc6d0d6496", "5", "AdminId" },
                    { "3a748317-8527-421e-bfb5-dbc04d8793f3", "3", "AdminId" },
                    { "5633410f-5314-46e4-b094-ece426ae01f8", "14", "HomeOwnerId" },
                    { "6d4c7ab0-abcb-4185-a22f-50d83aabeee9", "2", "AdminId" },
                    { "780cc1e7-2d08-4237-a8cc-b1ff303c31d0", "8", "CompanyOwnerId" },
                    { "7c66f416-3417-41b4-957a-ed8c90b0d83e", "13", "HomeOwnerId" },
                    { "90c254b6-c18b-47ab-bf35-1a7b5b853b51", "1", "AdminId" },
                    { "9d1bc010-b1b2-4088-a0b3-16bec2180fc1", "7", "CompanyOwnerId" },
                    { "a3993596-0ae4-4855-ade4-124fa881d9b7", "4", "AdminId" },
                    { "adf19ec7-0ecb-444e-905b-8c4cc4556264", "6", "CompanyOwnerId" },
                    { "bbfe61c4-b399-4e1f-80bd-517ad7da394d", "10", "HomeOwnerId" },
                    { "effa0af3-ebc8-4739-bd8f-e77884048aa7", "16", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "45b50fed-aa15-4026-83ab-1348f36385eb", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "97904c5a-a2d4-4fb9-8923-a2c0f3001d44", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "a0049d7d-ea2d-4718-9a1a-3a2138391adf", "AdminId", "SeedAdminId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "16/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "16/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "16/11/2024");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "074f6f7f-fbc9-4c0e-84b0-4d6a52f783d4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0b78b415-3078-403a-95e3-d8f229b65cd1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0dbe6875-a4b7-4b3c-8a9d-74c0a88448df");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0f96f5f3-5d24-436b-a818-be9bcea73f1b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "369f428b-fd14-4056-a671-9acc6d0d6496");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3a748317-8527-421e-bfb5-dbc04d8793f3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5633410f-5314-46e4-b094-ece426ae01f8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6d4c7ab0-abcb-4185-a22f-50d83aabeee9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "780cc1e7-2d08-4237-a8cc-b1ff303c31d0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7c66f416-3417-41b4-957a-ed8c90b0d83e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "90c254b6-c18b-47ab-bf35-1a7b5b853b51");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9d1bc010-b1b2-4088-a0b3-16bec2180fc1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a3993596-0ae4-4855-ade4-124fa881d9b7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "adf19ec7-0ecb-444e-905b-8c4cc4556264");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bbfe61c4-b399-4e1f-80bd-517ad7da394d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "effa0af3-ebc8-4739-bd8f-e77884048aa7");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "45b50fed-aa15-4026-83ab-1348f36385eb");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "97904c5a-a2d4-4fb9-8923-a2c0f3001d44");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "a0049d7d-ea2d-4718-9a1a-3a2138391adf");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "01a0adae-ebfb-4db6-82f6-97a025e65129", "7", "CompanyOwnerId" },
                    { "04b8ad0f-ae0d-499d-b7de-74202a3075ca", "3", "AdminId" },
                    { "0b94b21f-bf71-435e-89a7-2650cca804df", "8", "CompanyOwnerId" },
                    { "19e48745-0286-4420-9c54-1bce5f49474c", "17", "HomeOwnerId" },
                    { "2d8f9b1a-af97-4232-8823-12da6ccc97f3", "5", "AdminId" },
                    { "2f1baa39-9d85-4f97-a784-3b539a1c0926", "2", "AdminId" },
                    { "352ac4a4-625f-461d-9c99-b01f9c2bf2c9", "4", "AdminId" },
                    { "428af407-49c7-4e1d-a4fc-77d8b94a0de9", "13", "HomeOwnerId" },
                    { "5409905b-baf6-414f-965d-daa7c12f695f", "14", "HomeOwnerId" },
                    { "69bdb010-d551-4ed3-a6f7-b3e68ca2a218", "16", "HomeOwnerId" },
                    { "8593e115-8f4a-4c15-9ea6-0f3df404ffac", "18", "HomeOwnerId" },
                    { "8afec07e-d111-4d68-956f-b03aab696ad0", "1", "AdminId" },
                    { "8d771326-124a-472f-8d86-12399b3d7ff6", "12", "HomeOwnerId" },
                    { "a4963d93-98fc-4187-a2fc-69f2cd93efee", "9", "HomeOwnerId" },
                    { "b5384b1b-c938-4275-8f43-bf0b32b5d3e5", "19", "HomeOwnerId" },
                    { "bf494d18-0d54-423a-babb-4b3451c6c914", "11", "HomeOwnerId" },
                    { "c3b39c02-ddd0-4ae5-8b59-b9e6d2054fe0", "10", "HomeOwnerId" },
                    { "c740ac07-32c8-41aa-b390-dea6031d6038", "15", "HomeOwnerId" },
                    { "d0d568c3-765e-4b3b-a894-6835cba94c51", "6", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9e6badb2-186c-4e92-8092-7e156e98662d", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "b9759989-034f-4824-8f4b-ac7ded2ec4a7", "AdminId", "SeedAdminId" },
                    { "eecb396a-9b8d-4d8b-98ae-edb3b0134de4", "HomeOwnerId", "SeedHomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "15/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "15/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "15/11/2024");
        }
    }
}
