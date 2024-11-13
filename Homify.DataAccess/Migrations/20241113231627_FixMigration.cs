using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1e3d74b8-f01e-4a08-9238-30a4fe0ba9ee");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "21088647-3f46-43fb-a0f9-f8c4c6974def");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "41d661bb-ff63-42c3-be0d-9bb6ac4717f2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "44ee84f4-4f94-4231-9f35-e987d7dc4814");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "46cc4b15-be71-4157-acb3-82d0f83d8438");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4db25138-ff66-4968-b776-73b6bdc97558");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6a202ce4-7165-455b-9f6d-ec03ffa60f0b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "856f9de9-e6c5-4921-af59-ddc68bbe07e3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8e2a1f8d-6f4c-4948-b2ca-168d043c9f6e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9a6b50e1-5829-4890-a5be-3aa9f40379ed");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a0d56e23-4628-4e44-9c2f-adf2b80a30a2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a35d6f6c-2f0c-45dc-9b3e-340839a2d6f7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a36ee25b-6f5a-499b-adc4-a4df0158021d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c11617b4-7738-4bd5-bc26-a8a81218afc5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c703114e-f786-40fa-a055-289038aeb079");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d0c7678d-fb35-4717-b095-9fbb8c36818a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d239ae51-842d-4a6a-a0d8-88b4b475dc7f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e8f54b89-1923-4679-bdf0-b2353d8fd405");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "edb877ae-3336-4c90-a3f9-541550544fcd");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "30a4f70a-2ea2-4ad5-84f0-a598c0e14ed3");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "42f0c243-5ad1-479c-b731-085cd66aed3b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "5813e9e8-ca71-4072-9163-ac224d0d5ff9");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Lamps");

            migrationBuilder.AlterColumn<bool>(
                name: "PeopleDetection",
                table: "Devices",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "MovementDetection",
                table: "Devices",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsInterior",
                table: "Cameras",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsExterior",
                table: "Cameras",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Lamps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "PeopleDetection",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MovementDetection",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsInterior",
                table: "Cameras",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsExterior",
                table: "Cameras",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "1e3d74b8-f01e-4a08-9238-30a4fe0ba9ee", "5", "AdminId" },
                    { "21088647-3f46-43fb-a0f9-f8c4c6974def", "13", "HomeOwnerId" },
                    { "41d661bb-ff63-42c3-be0d-9bb6ac4717f2", "12", "HomeOwnerId" },
                    { "44ee84f4-4f94-4231-9f35-e987d7dc4814", "19", "HomeOwnerId" },
                    { "46cc4b15-be71-4157-acb3-82d0f83d8438", "3", "AdminId" },
                    { "4db25138-ff66-4968-b776-73b6bdc97558", "17", "HomeOwnerId" },
                    { "6a202ce4-7165-455b-9f6d-ec03ffa60f0b", "1", "AdminId" },
                    { "856f9de9-e6c5-4921-af59-ddc68bbe07e3", "18", "HomeOwnerId" },
                    { "8e2a1f8d-6f4c-4948-b2ca-168d043c9f6e", "6", "CompanyOwnerId" },
                    { "9a6b50e1-5829-4890-a5be-3aa9f40379ed", "10", "HomeOwnerId" },
                    { "a0d56e23-4628-4e44-9c2f-adf2b80a30a2", "11", "HomeOwnerId" },
                    { "a35d6f6c-2f0c-45dc-9b3e-340839a2d6f7", "7", "CompanyOwnerId" },
                    { "a36ee25b-6f5a-499b-adc4-a4df0158021d", "16", "HomeOwnerId" },
                    { "c11617b4-7738-4bd5-bc26-a8a81218afc5", "15", "HomeOwnerId" },
                    { "c703114e-f786-40fa-a055-289038aeb079", "4", "AdminId" },
                    { "d0c7678d-fb35-4717-b095-9fbb8c36818a", "9", "HomeOwnerId" },
                    { "d239ae51-842d-4a6a-a0d8-88b4b475dc7f", "8", "CompanyOwnerId" },
                    { "e8f54b89-1923-4679-bdf0-b2353d8fd405", "2", "AdminId" },
                    { "edb877ae-3336-4c90-a3f9-541550544fcd", "14", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "30a4f70a-2ea2-4ad5-84f0-a598c0e14ed3", "AdminId", "SeedAdminId" },
                    { "42f0c243-5ad1-479c-b731-085cd66aed3b", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "5813e9e8-ca71-4072-9163-ac224d0d5ff9", "CompanyOwnerId", "SeedCompanyOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "07/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "07/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "07/11/2024");
        }
    }
}
