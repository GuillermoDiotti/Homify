using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations;

/// <inheritdoc />
public partial class MergeBranches : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "0dc4b563-056b-4d05-a952-725315b04ee5");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1a61a5f7-1fae-4fb5-abdc-dba7550acea6");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "1d4ebc0a-0a1d-4814-91a3-702ce44b35b9");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "29aa78b7-82c0-4e6a-ab0f-6978a1e4cfb7");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "74b34941-e836-4488-8ca7-d3a7db8aee3a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "855be15d-f995-4f95-8bc3-658c744c0ad2");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "9610d6bd-e6af-46e5-ba5d-6f3911a75ade");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "a9f469fe-f8db-411b-80cb-fc578e900ffd");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ac492277-8833-449c-bd15-e272c1b08db8");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ac6623af-6c97-461e-8a4c-c8dc19d37a17");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "adcb6e0e-2c7c-4713-a324-7fe4cc82c16a");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ae7e133e-5127-4e54-a3d3-4203dbd5ca4c");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "b1863468-37db-4e35-84ca-d595698e22f8");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "c4320832-e75d-4e7b-9de8-50dadf188a52");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "d648f25b-9e8e-4cb2-aa05-32f9dafeac50");

        migrationBuilder.DeleteData(
            table: "RoleSystemPermissions",
            keyColumn: "RoleSystemPermissionId",
            keyValue: "ed558ee6-fea7-4037-90f3-73d52f50098d");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "00794575-d65a-4778-afd3-fd8601aa0ea6");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "4e231066-c2d9-4f4c-9e3e-78d0b0484827");

        migrationBuilder.DeleteData(
            table: "UserRoles",
            keyColumn: "Id",
            keyValue: "a408ba95-e947-403a-a400-cfea93d18f37");

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
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
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
                { "0dc4b563-056b-4d05-a952-725315b04ee5", "12", "HomeOwnerId" },
                { "1a61a5f7-1fae-4fb5-abdc-dba7550acea6", "5", "AdminId" },
                { "1d4ebc0a-0a1d-4814-91a3-702ce44b35b9", "7", "CompanyOwnerId" },
                { "29aa78b7-82c0-4e6a-ab0f-6978a1e4cfb7", "1", "AdminId" },
                { "74b34941-e836-4488-8ca7-d3a7db8aee3a", "15", "HomeOwnerId" },
                { "855be15d-f995-4f95-8bc3-658c744c0ad2", "6", "CompanyOwnerId" },
                { "9610d6bd-e6af-46e5-ba5d-6f3911a75ade", "11", "HomeOwnerId" },
                { "a9f469fe-f8db-411b-80cb-fc578e900ffd", "8", "CompanyOwnerId" },
                { "ac492277-8833-449c-bd15-e272c1b08db8", "3", "AdminId" },
                { "ac6623af-6c97-461e-8a4c-c8dc19d37a17", "4", "AdminId" },
                { "adcb6e0e-2c7c-4713-a324-7fe4cc82c16a", "2", "AdminId" },
                { "ae7e133e-5127-4e54-a3d3-4203dbd5ca4c", "10", "HomeOwnerId" },
                { "b1863468-37db-4e35-84ca-d595698e22f8", "16", "HomeOwnerId" },
                { "c4320832-e75d-4e7b-9de8-50dadf188a52", "14", "HomeOwnerId" },
                { "d648f25b-9e8e-4cb2-aa05-32f9dafeac50", "9", "HomeOwnerId" },
                { "ed558ee6-fea7-4037-90f3-73d52f50098d", "13", "HomeOwnerId" }
            });

        migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "Id", "RoleId", "UserId" },
            values: new object[,]
            {
                { "00794575-d65a-4778-afd3-fd8601aa0ea6", "HomeOwnerId", "SeedHomeOwnerId" },
                { "4e231066-c2d9-4f4c-9e3e-78d0b0484827", "CompanyOwnerId", "SeedCompanyOwnerId" },
                { "a408ba95-e947-403a-a400-cfea93d18f37", "AdminId", "SeedAdminId" }
            });
    }
}
