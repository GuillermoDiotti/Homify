using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Devices_Id",
                table: "Sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "02fa6bb2-8c95-47ff-9fb9-4411cfd66f61");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "301c2136-6d67-4f3d-a50e-e28a77979921");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "310693bc-b240-4ae8-9712-6c70a2d23d4f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "36ff634f-0f1c-42bc-988c-8e23aa16c099");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "37a3525e-eadd-4e40-af86-c5c7d10a1d96");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3d24ce3e-df61-41ba-98dc-cbe5f9fab60c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4a40824c-1571-4521-a405-3d6aaaa8d9e2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "687f2360-1a50-4292-8191-efc41daec86c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "799d038f-9653-4eed-a51e-06b8705c5183");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8c655182-d8e7-43cc-bc6d-1d353de6db10");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "963d6a4a-a3a4-4e3e-9d0d-c47884b26280");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "990ae0c8-5fbd-4549-81a2-9a5154763037");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9d71083b-67fb-4005-89a1-dea554b87839");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e2e4739f-125f-4447-89a0-fed83085b47c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e73825d2-5e88-4d7a-b315-ad5d6bce6542");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ee9b7384-cedf-4287-80bf-26b187024274");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "329da491-7d35-459b-9533-fbc6167e971e");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "9bdced61-c823-414a-83d9-28344017d5ef");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "d58ddc68-0854-4ebd-8f7f-5d31ca95168f");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "WindowSensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WindowSensors",
                table: "WindowSensors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "023dff9a-8db5-4925-a12c-2fee136cfaf0", "6", "CompanyOwnerId" },
                    { "0808ac79-165a-459d-a350-166fee7cfdcc", "2", "AdminId" },
                    { "0b3779b6-da44-4383-8dd6-636dfeed9cc4", "5", "AdminId" },
                    { "1a9e4e66-06a6-4b64-9713-302a76689857", "13", "HomeOwnerId" },
                    { "22c65973-aefe-4d7d-9d39-a282a0b44e86", "1", "AdminId" },
                    { "40897910-dedc-4eac-bb43-ab793d93763c", "4", "AdminId" },
                    { "41736df3-8ef7-4b98-9468-cdc2b9ed83f9", "15", "HomeOwnerId" },
                    { "57b3b112-396e-4424-8997-daafb0a92251", "9", "HomeOwnerId" },
                    { "7a61cf13-ee00-4178-8f1a-8f9682e47a5c", "11", "HomeOwnerId" },
                    { "9c865941-0018-40b6-a3c7-12606b26ea94", "7", "CompanyOwnerId" },
                    { "a9a9edaf-395a-46a9-9c7d-710b29e0ea3b", "12", "HomeOwnerId" },
                    { "b2ab0a90-60ea-48ee-8fd1-9fd714d85194", "3", "AdminId" },
                    { "c6542237-8ac9-46ed-8e56-1d2c33aa09b8", "8", "CompanyOwnerId" },
                    { "cd11d77f-9e63-46c7-b70c-7619f1208b96", "16", "HomeOwnerId" },
                    { "d9c5096c-111b-4774-91c4-04d148017e01", "14", "HomeOwnerId" },
                    { "e08fe78b-43fd-44d5-88a8-98dac6b0c462", "10", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "53a7148f-4e79-411b-8bda-794e73114a41", "AdminId", "SeedAdminId" },
                    { "5f1b3c8a-c62e-40b9-bec2-95e2af0f3140", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "69daeb22-b527-466f-a5f0-5f4f22f67681", "CompanyOwnerId", "SeedCompanyOwnerId" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WindowSensors_Devices_Id",
                table: "WindowSensors",
                column: "Id",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WindowSensors_Devices_Id",
                table: "WindowSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WindowSensors",
                table: "WindowSensors");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "023dff9a-8db5-4925-a12c-2fee136cfaf0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0808ac79-165a-459d-a350-166fee7cfdcc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0b3779b6-da44-4383-8dd6-636dfeed9cc4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "1a9e4e66-06a6-4b64-9713-302a76689857");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "22c65973-aefe-4d7d-9d39-a282a0b44e86");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "40897910-dedc-4eac-bb43-ab793d93763c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "41736df3-8ef7-4b98-9468-cdc2b9ed83f9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "57b3b112-396e-4424-8997-daafb0a92251");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7a61cf13-ee00-4178-8f1a-8f9682e47a5c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9c865941-0018-40b6-a3c7-12606b26ea94");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a9a9edaf-395a-46a9-9c7d-710b29e0ea3b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b2ab0a90-60ea-48ee-8fd1-9fd714d85194");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c6542237-8ac9-46ed-8e56-1d2c33aa09b8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cd11d77f-9e63-46c7-b70c-7619f1208b96");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d9c5096c-111b-4774-91c4-04d148017e01");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e08fe78b-43fd-44d5-88a8-98dac6b0c462");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "53a7148f-4e79-411b-8bda-794e73114a41");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "5f1b3c8a-c62e-40b9-bec2-95e2af0f3140");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "69daeb22-b527-466f-a5f0-5f4f22f67681");

            migrationBuilder.RenameTable(
                name: "WindowSensors",
                newName: "Sensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "02fa6bb2-8c95-47ff-9fb9-4411cfd66f61", "13", "HomeOwnerId" },
                    { "301c2136-6d67-4f3d-a50e-e28a77979921", "10", "HomeOwnerId" },
                    { "310693bc-b240-4ae8-9712-6c70a2d23d4f", "9", "HomeOwnerId" },
                    { "36ff634f-0f1c-42bc-988c-8e23aa16c099", "15", "HomeOwnerId" },
                    { "37a3525e-eadd-4e40-af86-c5c7d10a1d96", "5", "AdminId" },
                    { "3d24ce3e-df61-41ba-98dc-cbe5f9fab60c", "6", "CompanyOwnerId" },
                    { "4a40824c-1571-4521-a405-3d6aaaa8d9e2", "8", "CompanyOwnerId" },
                    { "687f2360-1a50-4292-8191-efc41daec86c", "16", "HomeOwnerId" },
                    { "799d038f-9653-4eed-a51e-06b8705c5183", "3", "AdminId" },
                    { "8c655182-d8e7-43cc-bc6d-1d353de6db10", "12", "HomeOwnerId" },
                    { "963d6a4a-a3a4-4e3e-9d0d-c47884b26280", "4", "AdminId" },
                    { "990ae0c8-5fbd-4549-81a2-9a5154763037", "7", "CompanyOwnerId" },
                    { "9d71083b-67fb-4005-89a1-dea554b87839", "2", "AdminId" },
                    { "e2e4739f-125f-4447-89a0-fed83085b47c", "14", "HomeOwnerId" },
                    { "e73825d2-5e88-4d7a-b315-ad5d6bce6542", "1", "AdminId" },
                    { "ee9b7384-cedf-4287-80bf-26b187024274", "11", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "329da491-7d35-459b-9533-fbc6167e971e", "AdminId", "SeedAdminId" },
                    { "9bdced61-c823-414a-83d9-28344017d5ef", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "d58ddc68-0854-4ebd-8f7f-5d31ca95168f", "HomeOwnerId", "SeedHomeOwnerId" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Devices_Id",
                table: "Sensors",
                column: "Id",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
