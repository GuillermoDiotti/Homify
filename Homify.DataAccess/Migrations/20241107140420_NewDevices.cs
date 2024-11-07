using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewDevices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "10a7547f-b03c-46b2-b787-f84a8efbdc6c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1cd49e3f-a0f8-4c56-93cd-cb7bac611e43");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "38fdbbdb-d1bb-478f-9a3a-2c1a44975f15");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "39b07b3c-1cdb-4a22-8d86-e90d0e3200d6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3d77aa9d-5789-430e-ab6b-3ff270b05c19");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4b501aff-0a1e-4d52-a163-cdb7833c5792");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5d394608-2819-4a50-85d0-883c8be16ba0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6572966b-630e-432c-8212-86d8e2ab61cc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "717d001e-56ac-446f-a02e-9058a1496b57");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "73788f33-47b7-4cf9-8b46-188b750890db");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "813aefdf-d608-4aee-a0a8-13c904e6058a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8cc003a6-18db-4b5a-bc18-b1a5e60b9fbc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "905d668b-8a90-4308-a20a-5023a2a65f7f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a3af3e88-acc8-491c-8c5d-1c475faa6aca");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a5395f3e-b5e4-456b-8417-532bba2962fc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bab54740-89b7-4fd7-9c5a-77d3158c1c29");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "eaf017eb-6d0c-41d4-90fc-b50b5a2401e5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f2f668b8-45e0-4916-aefa-16648a88c50f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f4cc5867-d7b5-413b-8017-b8c65d003b23");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "3cd380a2-6d7a-4bd0-b06c-16cdcb2cdf84");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "a887b2ee-f561-4d7d-aff1-1af61e1c4e5d");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "ad44ab69-77c1-4e11-9ba9-955c43496b55");

            migrationBuilder.CreateTable(
                name: "Lamps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lamps_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementSensors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementSensors_Devices_Id",
                        column: x => x.Id,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lamps");

            migrationBuilder.DropTable(
                name: "MovementSensors");

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

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "10a7547f-b03c-46b2-b787-f84a8efbdc6c", "17", "HomeOwnerId" },
                    { "1cd49e3f-a0f8-4c56-93cd-cb7bac611e43", "2", "AdminId" },
                    { "38fdbbdb-d1bb-478f-9a3a-2c1a44975f15", "6", "CompanyOwnerId" },
                    { "39b07b3c-1cdb-4a22-8d86-e90d0e3200d6", "4", "AdminId" },
                    { "3d77aa9d-5789-430e-ab6b-3ff270b05c19", "13", "HomeOwnerId" },
                    { "4b501aff-0a1e-4d52-a163-cdb7833c5792", "1", "AdminId" },
                    { "5d394608-2819-4a50-85d0-883c8be16ba0", "12", "HomeOwnerId" },
                    { "6572966b-630e-432c-8212-86d8e2ab61cc", "16", "HomeOwnerId" },
                    { "717d001e-56ac-446f-a02e-9058a1496b57", "3", "AdminId" },
                    { "73788f33-47b7-4cf9-8b46-188b750890db", "11", "HomeOwnerId" },
                    { "813aefdf-d608-4aee-a0a8-13c904e6058a", "14", "HomeOwnerId" },
                    { "8cc003a6-18db-4b5a-bc18-b1a5e60b9fbc", "19", "HomeOwnerId" },
                    { "905d668b-8a90-4308-a20a-5023a2a65f7f", "5", "AdminId" },
                    { "a3af3e88-acc8-491c-8c5d-1c475faa6aca", "15", "HomeOwnerId" },
                    { "a5395f3e-b5e4-456b-8417-532bba2962fc", "10", "HomeOwnerId" },
                    { "bab54740-89b7-4fd7-9c5a-77d3158c1c29", "18", "HomeOwnerId" },
                    { "eaf017eb-6d0c-41d4-90fc-b50b5a2401e5", "9", "HomeOwnerId" },
                    { "f2f668b8-45e0-4916-aefa-16648a88c50f", "8", "CompanyOwnerId" },
                    { "f4cc5867-d7b5-413b-8017-b8c65d003b23", "7", "CompanyOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3cd380a2-6d7a-4bd0-b06c-16cdcb2cdf84", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "a887b2ee-f561-4d7d-aff1-1af61e1c4e5d", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "ad44ab69-77c1-4e11-9ba9-955c43496b55", "AdminId", "SeedAdminId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "02/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "02/11/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "02/11/2024");
        }
    }
}
