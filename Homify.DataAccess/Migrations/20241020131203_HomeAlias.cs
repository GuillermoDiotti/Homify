using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class HomeAlias : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "07ff785e-b01a-42eb-b977-fcc4f616d1bd");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "26aacfe8-7e29-4b10-8454-ebec71aa0a1d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "2a8adeb6-e419-406b-8b72-c33c2cc448b6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "372859c6-5f86-43cc-ae7c-8d25c28c2d74");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "402879a4-045c-462f-879a-3cef9a290033");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4ae13fc9-dbcd-4241-a3ab-3bda8c3fc7ff");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "4dec03c0-a429-4ae1-9a6d-b1c26ccc0445");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5311ec22-6e91-4aa7-9d26-14f23700b668");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5891ee88-b504-470f-9551-7911e098d605");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5a2cd81f-605f-415f-b95f-8b282ea63f0e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "75969ed5-0945-441d-972a-8753ee5debd1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "77a304e0-5e34-4970-8cc5-ed3c22b729e7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "97071e4e-07ed-43d0-a45d-d86c9018407b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a2992f18-7b60-41ae-a87c-993889c50e6d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b09c59d0-e601-4d93-a8df-ba5b4ab0868b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c8b8e984-2fc3-4535-b1d5-3c971c1149df");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "d4814d3c-2750-4a0f-a2bf-30b20507e9cf");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "dc971f84-33e9-4efb-9127-14b10a67cdae");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ea61bbd4-2b4b-44f3-b03c-35804fec2777");

        migrationBuilder.AddColumn<string>(
            name: "Alias",
            table: "Homes",
            type: "nvarchar(max)",
            nullable: false);

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "011c6a7a-88c1-478a-b054-c15b864991c0", "4", "AdminId" },
                { "17cd672a-1f50-49f2-b339-477f6586a2c4", "15", "HomeOwnerId" },
                { "1873678d-6186-4112-982f-0b2a06d5536b", "17", "HomeOwnerId" },
                { "239f7c03-78cd-4fb5-bd98-dae0ec784998", "19", "HomeOwnerId" },
                { "3736eba5-afde-4f66-9793-c5738888f83e", "16", "HomeOwnerId" },
                { "3ec46b4c-fbec-41b0-b7d1-7fa129e13baa", "10", "HomeOwnerId" },
                { "44d222c4-6588-4f95-bd7b-fca4b54b9ec4", "13", "HomeOwnerId" },
                { "594ecfd5-00c8-4b54-9b8d-0a43d033acf7", "12", "HomeOwnerId" },
                { "5a5858b8-ed8b-4938-a932-86b01d9fb20e", "1", "AdminId" },
                { "61fb7280-648d-434c-8f46-b3a2bfcfeea6", "6", "CompanyOwnerId" },
                { "7940a2a9-e4af-4ba9-a0ad-a946695fec91", "5", "AdminId" },
                { "7cccbe64-43da-401a-b51a-f71a5abfbb7f", "11", "HomeOwnerId" },
                { "82ebfb91-b508-4723-9dd6-a3d178d5c621", "2", "AdminId" },
                { "a3a1d21c-9e30-45e7-8d79-7495250acdb1", "9", "HomeOwnerId" },
                { "b02d8d75-3c53-4585-8528-fd31af3e148d", "7", "CompanyOwnerId" },
                { "bc1d62c7-ffbd-4783-bcb5-5218e62ac39a", "3", "AdminId" },
                { "bd10dff4-c859-466e-ba62-dcdf5cf4faf6", "14", "HomeOwnerId" },
                { "e1527ec5-bc40-4ee0-80e8-32dc79656f94", "8", "CompanyOwnerId" },
                { "fce29dbc-28a9-474f-9ab5-4b8a952e3259", "18", "HomeOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: "20/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: "20/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: "20/10/2024");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "011c6a7a-88c1-478a-b054-c15b864991c0");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "17cd672a-1f50-49f2-b339-477f6586a2c4");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1873678d-6186-4112-982f-0b2a06d5536b");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "239f7c03-78cd-4fb5-bd98-dae0ec784998");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3736eba5-afde-4f66-9793-c5738888f83e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "3ec46b4c-fbec-41b0-b7d1-7fa129e13baa");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "44d222c4-6588-4f95-bd7b-fca4b54b9ec4");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "594ecfd5-00c8-4b54-9b8d-0a43d033acf7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "5a5858b8-ed8b-4938-a932-86b01d9fb20e");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "61fb7280-648d-434c-8f46-b3a2bfcfeea6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7940a2a9-e4af-4ba9-a0ad-a946695fec91");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "7cccbe64-43da-401a-b51a-f71a5abfbb7f");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "82ebfb91-b508-4723-9dd6-a3d178d5c621");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a3a1d21c-9e30-45e7-8d79-7495250acdb1");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b02d8d75-3c53-4585-8528-fd31af3e148d");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "bc1d62c7-ffbd-4783-bcb5-5218e62ac39a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "bd10dff4-c859-466e-ba62-dcdf5cf4faf6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "e1527ec5-bc40-4ee0-80e8-32dc79656f94");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "fce29dbc-28a9-474f-9ab5-4b8a952e3259");

        migrationBuilder.DropColumn(
            name: "Alias",
            table: "Homes");

        migrationBuilder.InsertData(
            table: "RoleSystemPermissions",
            columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
            values: new object[,]
            {
                { "07ff785e-b01a-42eb-b977-fcc4f616d1bd", "16", "HomeOwnerId" },
                { "26aacfe8-7e29-4b10-8454-ebec71aa0a1d", "11", "HomeOwnerId" },
                { "2a8adeb6-e419-406b-8b72-c33c2cc448b6", "17", "HomeOwnerId" },
                { "372859c6-5f86-43cc-ae7c-8d25c28c2d74", "18", "HomeOwnerId" },
                { "402879a4-045c-462f-879a-3cef9a290033", "15", "HomeOwnerId" },
                { "4ae13fc9-dbcd-4241-a3ab-3bda8c3fc7ff", "9", "HomeOwnerId" },
                { "4dec03c0-a429-4ae1-9a6d-b1c26ccc0445", "19", "HomeOwnerId" },
                { "5311ec22-6e91-4aa7-9d26-14f23700b668", "5", "AdminId" },
                { "5891ee88-b504-470f-9551-7911e098d605", "13", "HomeOwnerId" },
                { "5a2cd81f-605f-415f-b95f-8b282ea63f0e", "2", "AdminId" },
                { "75969ed5-0945-441d-972a-8753ee5debd1", "10", "HomeOwnerId" },
                { "77a304e0-5e34-4970-8cc5-ed3c22b729e7", "3", "AdminId" },
                { "97071e4e-07ed-43d0-a45d-d86c9018407b", "12", "HomeOwnerId" },
                { "a2992f18-7b60-41ae-a87c-993889c50e6d", "4", "AdminId" },
                { "b09c59d0-e601-4d93-a8df-ba5b4ab0868b", "6", "CompanyOwnerId" },
                { "c8b8e984-2fc3-4535-b1d5-3c971c1149df", "14", "HomeOwnerId" },
                { "d4814d3c-2750-4a0f-a2bf-30b20507e9cf", "1", "AdminId" },
                { "dc971f84-33e9-4efb-9127-14b10a67cdae", "8", "CompanyOwnerId" },
                { "ea61bbd4-2b4b-44f3-b03c-35804fec2777", "7", "CompanyOwnerId" }
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedAdminId",
            column: "CreatedAt",
            value: "18/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedCompanyOwnerId",
            column: "CreatedAt",
            value: "18/10/2024");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: "SeedHomeOwnerId",
            column: "CreatedAt",
            value: "18/10/2024");
    }
}
