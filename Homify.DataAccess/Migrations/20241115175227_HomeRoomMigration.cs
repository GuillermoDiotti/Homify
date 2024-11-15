using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class HomeRoomMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "00e3c902-c7fe-42ea-8f1e-3f6263067936");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0805d504-99a6-4f18-81a1-71d5f2c31779");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "10c1f243-eef0-4797-9737-40a6dc7c4432");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1330f545-e998-42dd-b94c-1fa4dba30994");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1f19ea32-354b-428a-91b1-6c4e0bb15438");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "274316f0-59c2-4fd6-8f91-a8d0219b5341");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4aeb168b-25d0-4d39-8c53-7312dc1dc0ad");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "509ec618-ede6-41b1-ba2f-9d2940eab791");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5847cb1a-5e88-44a1-8e15-4ed9250fce34");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "642e8f1f-56fb-49e0-b9ac-2be33e1d71b3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "82750fe3-a575-4011-af94-b26d905cdb76");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a04d4a9d-ecea-492f-913c-09a6237746f0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a0abe56b-0dc8-4576-ac7e-05c4b70c87c9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a34271ce-e611-4be7-9125-d9dbe4ad1b47");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a8e1a964-2d2b-47a5-96ca-be60fa696e0b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c1c1c4cb-8c5d-4eea-9d4e-11a4f00482b7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ced186db-fe88-4b49-84ba-834b09fcba7c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d16ab464-8d6d-4dc6-bd86-485e5941b5fe");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "de73e70b-0f98-45c4-bf8f-37f06f484025");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "7aeb7794-33a6-4501-8296-fe9bac57ab12");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "7fc15178-8c32-4d51-abb2-d9aa12e75a3f");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "e98f4387-d266-4dda-8a8b-acc7962b34ed");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0c3a8b4c-b4ef-4ce7-b261-c85a50e56571", "5", "AdminId" },
                    { "20d6c10f-71f6-4786-ab0b-a1e31ff54d4d", "14", "HomeOwnerId" },
                    { "2736719d-18f5-4d02-8a94-7fe5d04dcf0b", "16", "HomeOwnerId" },
                    { "3809ca52-8b54-4522-9157-485380a2f0c4", "2", "AdminId" },
                    { "3b6a45f3-2cc9-4a2d-8e00-1369a17b0b3d", "6", "CompanyOwnerId" },
                    { "43b3dd25-9606-4b93-86a4-8aeb05724b09", "9", "HomeOwnerId" },
                    { "4882d718-f7bb-467b-afbb-3ba5f85ebf2a", "7", "CompanyOwnerId" },
                    { "4f75fa96-6ce9-495e-911b-4d3f7d1fe32e", "15", "HomeOwnerId" },
                    { "6817a11e-22c0-42ee-a655-1f147b5fbfec", "18", "HomeOwnerId" },
                    { "6a58cc09-d7c7-460f-9c16-30de94f9040f", "3", "AdminId" },
                    { "a19d44d2-ca1b-495a-b90f-f0cce05663c0", "10", "HomeOwnerId" },
                    { "a26c4f95-e7bf-440d-b8bc-aa865a171099", "8", "CompanyOwnerId" },
                    { "abc87c2b-5e17-44d8-83f9-a98962fcc2dd", "1", "AdminId" },
                    { "b02b6f76-b399-4b91-9e77-c9de2e03e9e9", "11", "HomeOwnerId" },
                    { "b8297b4f-4de9-48f8-986e-d71d18f57cc0", "12", "HomeOwnerId" },
                    { "d22617fd-37b5-4f6d-933a-33dc0e08ebac", "19", "HomeOwnerId" },
                    { "dbf7f873-24c8-4ea5-8998-4d7b42a8dafd", "13", "HomeOwnerId" },
                    { "e30db2fb-8701-4f54-85cd-f524d2e97d49", "4", "AdminId" },
                    { "e7840ce8-f21a-4bab-b591-8df50943a0b4", "17", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "038a76c1-6782-4b0e-9a3a-8c32b7118349", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "b35d41a9-88cb-475c-9b9c-2fa8bd04b1f3", "AdminId", "SeedAdminId" },
                    { "ff9c1d22-89fc-40d1-9e53-68bb29a12668", "CompanyOwnerId", "SeedCompanyOwnerId" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0c3a8b4c-b4ef-4ce7-b261-c85a50e56571");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "20d6c10f-71f6-4786-ab0b-a1e31ff54d4d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2736719d-18f5-4d02-8a94-7fe5d04dcf0b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3809ca52-8b54-4522-9157-485380a2f0c4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3b6a45f3-2cc9-4a2d-8e00-1369a17b0b3d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "43b3dd25-9606-4b93-86a4-8aeb05724b09");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4882d718-f7bb-467b-afbb-3ba5f85ebf2a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4f75fa96-6ce9-495e-911b-4d3f7d1fe32e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6817a11e-22c0-42ee-a655-1f147b5fbfec");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6a58cc09-d7c7-460f-9c16-30de94f9040f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a19d44d2-ca1b-495a-b90f-f0cce05663c0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a26c4f95-e7bf-440d-b8bc-aa865a171099");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "abc87c2b-5e17-44d8-83f9-a98962fcc2dd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b02b6f76-b399-4b91-9e77-c9de2e03e9e9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b8297b4f-4de9-48f8-986e-d71d18f57cc0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d22617fd-37b5-4f6d-933a-33dc0e08ebac");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "dbf7f873-24c8-4ea5-8998-4d7b42a8dafd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e30db2fb-8701-4f54-85cd-f524d2e97d49");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e7840ce8-f21a-4bab-b591-8df50943a0b4");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "038a76c1-6782-4b0e-9a3a-8c32b7118349");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "b35d41a9-88cb-475c-9b9c-2fa8bd04b1f3");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "ff9c1d22-89fc-40d1-9e53-68bb29a12668");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "00e3c902-c7fe-42ea-8f1e-3f6263067936", "6", "CompanyOwnerId" },
                    { "0805d504-99a6-4f18-81a1-71d5f2c31779", "4", "AdminId" },
                    { "10c1f243-eef0-4797-9737-40a6dc7c4432", "10", "HomeOwnerId" },
                    { "1330f545-e998-42dd-b94c-1fa4dba30994", "8", "CompanyOwnerId" },
                    { "1f19ea32-354b-428a-91b1-6c4e0bb15438", "11", "HomeOwnerId" },
                    { "274316f0-59c2-4fd6-8f91-a8d0219b5341", "19", "HomeOwnerId" },
                    { "4aeb168b-25d0-4d39-8c53-7312dc1dc0ad", "7", "CompanyOwnerId" },
                    { "509ec618-ede6-41b1-ba2f-9d2940eab791", "3", "AdminId" },
                    { "5847cb1a-5e88-44a1-8e15-4ed9250fce34", "5", "AdminId" },
                    { "642e8f1f-56fb-49e0-b9ac-2be33e1d71b3", "16", "HomeOwnerId" },
                    { "82750fe3-a575-4011-af94-b26d905cdb76", "18", "HomeOwnerId" },
                    { "a04d4a9d-ecea-492f-913c-09a6237746f0", "12", "HomeOwnerId" },
                    { "a0abe56b-0dc8-4576-ac7e-05c4b70c87c9", "9", "HomeOwnerId" },
                    { "a34271ce-e611-4be7-9125-d9dbe4ad1b47", "13", "HomeOwnerId" },
                    { "a8e1a964-2d2b-47a5-96ca-be60fa696e0b", "15", "HomeOwnerId" },
                    { "c1c1c4cb-8c5d-4eea-9d4e-11a4f00482b7", "2", "AdminId" },
                    { "ced186db-fe88-4b49-84ba-834b09fcba7c", "1", "AdminId" },
                    { "d16ab464-8d6d-4dc6-bd86-485e5941b5fe", "17", "HomeOwnerId" },
                    { "de73e70b-0f98-45c4-bf8f-37f06f484025", "14", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7aeb7794-33a6-4501-8296-fe9bac57ab12", "AdminId", "SeedAdminId" },
                    { "7fc15178-8c32-4d51-abb2-d9aa12e75a3f", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "e98f4387-d266-4dda-8a8b-acc7962b34ed", "HomeOwnerId", "SeedHomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "13/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "13/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "13/11/2024");
        }
    }
}
