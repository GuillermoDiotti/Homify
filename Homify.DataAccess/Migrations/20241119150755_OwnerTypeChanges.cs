using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class OwnerTypeChanges : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Homes_HomeOwners_OwnerId",
            table: "Homes");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "04310d63-bbf4-4757-93b7-522c42249dad");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "084a09e5-bd30-4ae0-aaa3-3d4278aefc2f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1002f143-de8b-40ee-bff2-d9e410b2966b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "26e1aff4-dc16-4396-bf90-c19230b631b8");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3520d142-5e72-4a04-8ca2-ac58b7fdafe7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4019de9f-b1b0-4e92-af9c-162816d58c9c");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7b02957c-a665-4237-86a1-838b2697ec8e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "9d823876-7293-4600-8dcd-c24ec70745f4");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "9dadb15a-3e0d-4ff6-a6a0-9daeeac489c0");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "9ffffc45-88ef-44e7-842c-f6fc20bbc0ee");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a4879157-6144-40ed-8df7-d50db59ce026");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b283ae85-57c1-4c72-bb45-042a91e27b2e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b487f0bc-9bbf-4bee-8e64-cb41612a34be");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ca84489b-4bde-4dff-8725-c27404bf3cb1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ed8e32a2-8171-42fe-8a47-7932a0925889");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "f72653f7-9945-449b-ba15-55860c142e68");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "3be22b74-42cb-44b8-bcaa-198a5846379e");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "914dc5e2-dbf9-48ff-bfcf-7d41e4010762");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "a47f6035-5b19-4dff-a233-99bea8863e89");

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "0a17167d-6598-4d9c-a247-9b08fa9ebd7d", "16", "HomeOwnerId" },
                { "0e0a0b76-70a6-4420-98e1-22faab5dfbf0", "8", "CompanyOwnerId" },
                { "1bc8c721-ff01-4d46-b6ca-4416062d1756", "2", "AdminId" },
                { "27a1c650-ce0c-425e-82e8-5de241cbec3c", "5", "AdminId" },
                { "310fc077-226c-401e-9a14-a602ec1d3ad2", "11", "HomeOwnerId" },
                { "3d2e86a6-aaa4-4dff-8b63-ad24e4d91ad7", "6", "CompanyOwnerId" },
                { "4167abf7-702d-461b-82ee-28af5355a186", "9", "HomeOwnerId" },
                { "55b51a82-4044-440c-9b0b-f7705e1ef0db", "15", "HomeOwnerId" },
                { "55b96a30-2b1d-4304-bfb3-bc5fbd65cc25", "3", "AdminId" },
                { "572516d1-beaa-4ca5-9a88-7cca9c852d30", "1", "AdminId" },
                { "7bfbeb2b-8b07-4cd2-94f1-ea329db0d936", "14", "HomeOwnerId" },
                { "8e3f7292-51ce-469b-ba80-4da5ff665a68", "10", "HomeOwnerId" },
                { "8fb054cc-79bf-4d7a-8d69-a9c6d55fcc8b", "13", "HomeOwnerId" },
                { "a22068a3-4dd2-4f59-b6b5-6c82eacd035f", "7", "CompanyOwnerId" },
                { "ac982990-98e0-4394-9df2-48512b9127af", "12", "HomeOwnerId" },
                { "b0d90a14-e545-41d3-a5f2-faca21acc63c", "4", "AdminId" }
            });

        migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "Id", "RoleId", "UserId" },
            values: new object[,]
            {
                { "022da7dd-6f76-47f2-8b26-e70c03dee423", "HomeOwnerId", "SeedHomeOwnerId" },
                { "23036a55-26cb-465a-8798-97efc0a6c13d", "CompanyOwnerId", "SeedCompanyOwnerId" },
                { "b391d804-8daf-4df0-919e-755b0df9e9ba", "AdminId", "SeedAdminId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: "19/11/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: "19/11/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: "19/11/2024");

        migrationBuilder.AddForeignKey(
            name: "FK_Homes_Users_OwnerId",
            table: "Homes",
            column: "OwnerId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Homes_Users_OwnerId",
            table: "Homes");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0a17167d-6598-4d9c-a247-9b08fa9ebd7d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0e0a0b76-70a6-4420-98e1-22faab5dfbf0");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1bc8c721-ff01-4d46-b6ca-4416062d1756");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "27a1c650-ce0c-425e-82e8-5de241cbec3c");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "310fc077-226c-401e-9a14-a602ec1d3ad2");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3d2e86a6-aaa4-4dff-8b63-ad24e4d91ad7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4167abf7-702d-461b-82ee-28af5355a186");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "55b51a82-4044-440c-9b0b-f7705e1ef0db");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "55b96a30-2b1d-4304-bfb3-bc5fbd65cc25");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "572516d1-beaa-4ca5-9a88-7cca9c852d30");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7bfbeb2b-8b07-4cd2-94f1-ea329db0d936");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "8e3f7292-51ce-469b-ba80-4da5ff665a68");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "8fb054cc-79bf-4d7a-8d69-a9c6d55fcc8b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a22068a3-4dd2-4f59-b6b5-6c82eacd035f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ac982990-98e0-4394-9df2-48512b9127af");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b0d90a14-e545-41d3-a5f2-faca21acc63c");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "022da7dd-6f76-47f2-8b26-e70c03dee423");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "23036a55-26cb-465a-8798-97efc0a6c13d");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "b391d804-8daf-4df0-919e-755b0df9e9ba");

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "04310d63-bbf4-4757-93b7-522c42249dad", "7", "CompanyOwnerId" },
                { "084a09e5-bd30-4ae0-aaa3-3d4278aefc2f", "14", "HomeOwnerId" },
                { "1002f143-de8b-40ee-bff2-d9e410b2966b", "13", "HomeOwnerId" },
                { "26e1aff4-dc16-4396-bf90-c19230b631b8", "15", "HomeOwnerId" },
                { "3520d142-5e72-4a04-8ca2-ac58b7fdafe7", "3", "AdminId" },
                { "4019de9f-b1b0-4e92-af9c-162816d58c9c", "10", "HomeOwnerId" },
                { "7b02957c-a665-4237-86a1-838b2697ec8e", "12", "HomeOwnerId" },
                { "9d823876-7293-4600-8dcd-c24ec70745f4", "9", "HomeOwnerId" },
                { "9dadb15a-3e0d-4ff6-a6a0-9daeeac489c0", "1", "AdminId" },
                { "9ffffc45-88ef-44e7-842c-f6fc20bbc0ee", "8", "CompanyOwnerId" },
                { "a4879157-6144-40ed-8df7-d50db59ce026", "6", "CompanyOwnerId" },
                { "b283ae85-57c1-4c72-bb45-042a91e27b2e", "11", "HomeOwnerId" },
                { "b487f0bc-9bbf-4bee-8e64-cb41612a34be", "4", "AdminId" },
                { "ca84489b-4bde-4dff-8725-c27404bf3cb1", "5", "AdminId" },
                { "ed8e32a2-8171-42fe-8a47-7932a0925889", "16", "HomeOwnerId" },
                { "f72653f7-9945-449b-ba15-55860c142e68", "2", "AdminId" }
            });

        migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "Id", "RoleId", "UserId" },
            values: new object[,]
            {
                { "3be22b74-42cb-44b8-bcaa-198a5846379e", "AdminId", "SeedAdminId" },
                { "914dc5e2-dbf9-48ff-bfcf-7d41e4010762", "CompanyOwnerId", "SeedCompanyOwnerId" },
                { "a47f6035-5b19-4dff-a233-99bea8863e89", "HomeOwnerId", "SeedHomeOwnerId" }
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

        migrationBuilder.AddForeignKey(
            name: "FK_Homes_HomeOwners_OwnerId",
            table: "Homes",
            column: "OwnerId",
            principalTable: "HomeOwners",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
