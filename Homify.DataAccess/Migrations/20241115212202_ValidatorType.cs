using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class ValidatorType : Migration
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

        migrationBuilder.AddColumn<string>(
            name: "ValidatorType",
            table: "Companies",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: string.Empty);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: ["RoleSystemPermissionId", "PermissionId", "RoleId"],
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
            columns: ["Id", "RoleId", "UserId"],
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

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
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

        migrationBuilder.DropColumn(
            name: "ValidatorType",
            table: "Companies");

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: ["RoleSystemPermissionId", "PermissionId", "RoleId"],
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
            columns: ["Id", "RoleId", "UserId"],
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
