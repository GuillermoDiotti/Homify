using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewHomeDevicePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "08764d78-27f6-42d0-967b-e238046f49f0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "176fcc86-bb03-4d6b-adee-6e3d67249ff7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "201bf294-9484-4f44-bcb9-ccc03eecb195");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "25f914f1-ad51-43d9-9874-440d63e0a51d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "27193b47-a305-440c-abfc-029f81109652");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "36d111f7-4d62-4b51-97b7-4601568411e4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4232f56f-217d-4e3c-b133-fbeb4ba8991c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7ed015ed-84d0-471e-968b-b6bb6029fd99");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "844cdc2c-de12-4758-99ca-02633dcb9efe");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "917d161f-e54e-4f1f-b02c-d48444a733c4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ab14c14e-7fa6-4fb9-9ed5-0e80d0b66d94");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ba97f7e7-414d-48fd-a341-0a7a48805833");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "bd264121-97d4-4a05-94f0-df398fb0aee6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "da2b9eea-0041-43e3-af78-fc4fa588dec7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "dd3a4283-ea06-4ad0-b519-63d1ad2234a4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f1cbb313-22f7-4c00-86f9-9c2ed71ba51e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f3c61d5b-3e8c-4f39-bd36-5feecf54b860");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f550f58b-54c6-4872-adfd-9035fdf4c2e0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fea3cee1-6a0b-4dcc-9da1-65316c7cc400");

            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "HomeDevices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "2",
                column: "Value",
                value: "ListDevices");

            migrationBuilder.UpdateData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "3",
                column: "Value",
                value: "ChangeDeviceName");

            migrationBuilder.InsertData(
                table: "HomePermission",
                columns: new[] { "Id", "Value" },
                values: new object[] { "1", "AddDevices" });

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0415b735-aca3-4253-8564-2e122e819e89", "13", "HomeOwnerId" },
                    { "15a63621-3abf-4142-9c9c-377a49fcd7c7", "4", "AdminId" },
                    { "2bdd8862-1214-4fec-8047-5222827df2b4", "9", "HomeOwnerId" },
                    { "471859c5-83ce-45a6-8051-1385e1a6bee6", "6", "CompanyOwnerId" },
                    { "4e2b5b9f-3e6d-48b3-9a21-c687b29ad668", "17", "HomeOwnerId" },
                    { "7c13079b-9645-4049-9faa-4eb63a3340c0", "5", "AdminId" },
                    { "7f9dc5eb-17a2-4d59-bdf7-8ea35fab27b2", "8", "CompanyOwnerId" },
                    { "805afbe0-a74f-4f02-8bd1-3ddc99f62297", "7", "CompanyOwnerId" },
                    { "8d3c7d33-5dce-4f90-9db8-b720f3c1c113", "12", "HomeOwnerId" },
                    { "90f9403d-8d05-40b6-89b9-d57a6b89160a", "14", "HomeOwnerId" },
                    { "921112d4-316d-4ff7-beaf-d26a094abf56", "15", "HomeOwnerId" },
                    { "93d35014-55f2-43fc-83cb-9fc5abd0a440", "11", "HomeOwnerId" },
                    { "9e4c9a81-23d5-4ce9-b79a-38fce0b89300", "18", "HomeOwnerId" },
                    { "a16a4bff-133f-4e59-aa10-7c01b8d0657f", "16", "HomeOwnerId" },
                    { "b6a21efa-dac7-4161-82f3-2e9547a70145", "3", "AdminId" },
                    { "c40bde0f-d319-4004-856d-0e44b340a02d", "2", "AdminId" },
                    { "d7306b1f-38f0-4cbf-976c-c165bb314ea3", "1", "AdminId" },
                    { "d92c713d-2ad4-493c-a88f-d4bc0fb186ab", "10", "HomeOwnerId" },
                    { "f9e56a29-fb6d-4e09-b611-d4385a255992", "19", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "28/10/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "28/10/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "28/10/2024");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0415b735-aca3-4253-8564-2e122e819e89");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "15a63621-3abf-4142-9c9c-377a49fcd7c7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2bdd8862-1214-4fec-8047-5222827df2b4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "471859c5-83ce-45a6-8051-1385e1a6bee6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4e2b5b9f-3e6d-48b3-9a21-c687b29ad668");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7c13079b-9645-4049-9faa-4eb63a3340c0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7f9dc5eb-17a2-4d59-bdf7-8ea35fab27b2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "805afbe0-a74f-4f02-8bd1-3ddc99f62297");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8d3c7d33-5dce-4f90-9db8-b720f3c1c113");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "90f9403d-8d05-40b6-89b9-d57a6b89160a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "921112d4-316d-4ff7-beaf-d26a094abf56");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "93d35014-55f2-43fc-83cb-9fc5abd0a440");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9e4c9a81-23d5-4ce9-b79a-38fce0b89300");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a16a4bff-133f-4e59-aa10-7c01b8d0657f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b6a21efa-dac7-4161-82f3-2e9547a70145");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c40bde0f-d319-4004-856d-0e44b340a02d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d7306b1f-38f0-4cbf-976c-c165bb314ea3");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d92c713d-2ad4-493c-a88f-d4bc0fb186ab");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f9e56a29-fb6d-4e09-b611-d4385a255992");

            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "HomeDevices");

            migrationBuilder.UpdateData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "2",
                column: "Value",
                value: "AddDevices");

            migrationBuilder.UpdateData(
                table: "HomePermission",
                keyColumn: "Id",
                keyValue: "3",
                column: "Value",
                value: "ListDevices");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "08764d78-27f6-42d0-967b-e238046f49f0", "16", "HomeOwnerId" },
                    { "176fcc86-bb03-4d6b-adee-6e3d67249ff7", "5", "AdminId" },
                    { "201bf294-9484-4f44-bcb9-ccc03eecb195", "8", "CompanyOwnerId" },
                    { "25f914f1-ad51-43d9-9874-440d63e0a51d", "19", "HomeOwnerId" },
                    { "27193b47-a305-440c-abfc-029f81109652", "11", "HomeOwnerId" },
                    { "36d111f7-4d62-4b51-97b7-4601568411e4", "18", "HomeOwnerId" },
                    { "4232f56f-217d-4e3c-b133-fbeb4ba8991c", "7", "CompanyOwnerId" },
                    { "7ed015ed-84d0-471e-968b-b6bb6029fd99", "14", "HomeOwnerId" },
                    { "844cdc2c-de12-4758-99ca-02633dcb9efe", "13", "HomeOwnerId" },
                    { "917d161f-e54e-4f1f-b02c-d48444a733c4", "6", "CompanyOwnerId" },
                    { "ab14c14e-7fa6-4fb9-9ed5-0e80d0b66d94", "15", "HomeOwnerId" },
                    { "ba97f7e7-414d-48fd-a341-0a7a48805833", "3", "AdminId" },
                    { "bd264121-97d4-4a05-94f0-df398fb0aee6", "17", "HomeOwnerId" },
                    { "da2b9eea-0041-43e3-af78-fc4fa588dec7", "1", "AdminId" },
                    { "dd3a4283-ea06-4ad0-b519-63d1ad2234a4", "10", "HomeOwnerId" },
                    { "f1cbb313-22f7-4c00-86f9-9c2ed71ba51e", "9", "HomeOwnerId" },
                    { "f3c61d5b-3e8c-4f39-bd36-5feecf54b860", "2", "AdminId" },
                    { "f550f58b-54c6-4872-adfd-9035fdf4c2e0", "4", "AdminId" },
                    { "fea3cee1-6a0b-4dcc-9da1-65316c7cc400", "12", "HomeOwnerId" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedAdminId",
                column: "CreatedAt",
                value: "21/10/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedCompanyOwnerId",
                column: "CreatedAt",
                value: "21/10/2024");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "SeedHomeOwnerId",
                column: "CreatedAt",
                value: "21/10/2024");
        }
    }
}
