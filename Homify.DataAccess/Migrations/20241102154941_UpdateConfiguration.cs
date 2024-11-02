using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "03ad2fe6-1507-4695-a56a-72c069b130d4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "15eb0103-71bf-4c61-b60d-0c1b27ac4a47");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "231e51cd-ce64-445d-9f1f-1a1b9e9ee452");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "38ed22ee-73ff-4902-9104-37aab0a3498f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3a482be9-5c43-417c-a376-8a6862af2a1d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7e00431f-8113-48a9-a6ce-d8baea957aa2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "80d08fc6-059f-4470-a57d-fdc5c7f46155");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8d39ac80-9185-4b07-990e-ff46de2f6835");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "93010585-450c-4fb7-8863-b9aff7a208d9");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a13f27f8-c609-438d-9f4c-ab2b1c0420d0");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a24fe266-78ef-4d31-92fd-c77e56dbb44e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a51c131e-7a5c-4744-9aba-ea88f5748d6b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a94cf882-0010-412b-835b-ded792f7fa9c");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b1885178-bc39-4361-a9bc-3b48454dea80");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b3395568-dcea-4dfe-b7f9-2edbe193dc72");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "b82f79c2-26f5-4ae9-90ed-55726be1c3a2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ba9198eb-7df8-4ccf-8054-10080ce31ff8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c47909d3-fb55-4f2f-87a4-9234a0bc94f5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c8bfe1c9-c9b2-4f42-9dc9-804e39f23679");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "4431a628-9851-4c38-a216-e62c6ddcd475");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "a47c8454-9928-4197-b5f8-7c4423b597a1");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "c2c861d8-562a-4693-99c7-66d5e30ec390");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0fe9f137-804d-422d-9523-8fb200875db8", "13", "HomeOwnerId" },
                    { "19cc6758-ae2e-44cb-b7df-95990d44c676", "6", "CompanyOwnerId" },
                    { "34894d8e-a618-4655-be1b-6969835662cc", "8", "CompanyOwnerId" },
                    { "3d9a7a71-acfb-484c-b39e-70a0dc13d18a", "2", "AdminId" },
                    { "3ef96c9b-706e-467e-b12a-82b1202dbd99", "10", "HomeOwnerId" },
                    { "47be7b51-b757-4728-bffc-cc8de299a53d", "3", "AdminId" },
                    { "5119448f-3210-45c0-b8eb-a867b9961d0d", "7", "CompanyOwnerId" },
                    { "5952af66-6ffe-4c3b-ad99-4fcb82a383b4", "12", "HomeOwnerId" },
                    { "6c068b64-874e-4d71-972d-fcb2e2a69bbf", "17", "HomeOwnerId" },
                    { "81e6cac6-217b-4aee-8299-1e86912cbbf6", "18", "HomeOwnerId" },
                    { "90a78fab-3d3a-4dbf-9fd3-6201b01bdb43", "16", "HomeOwnerId" },
                    { "92759e0c-7632-4d29-bcf0-7339f9e10950", "14", "HomeOwnerId" },
                    { "9a8c9d73-8083-4aae-89c8-04b1a848bd23", "9", "HomeOwnerId" },
                    { "9cbc4a29-9a87-4c11-b677-beb791c51eab", "11", "HomeOwnerId" },
                    { "a7d0c17d-f174-463b-831f-56f56f26ccd7", "19", "HomeOwnerId" },
                    { "cc6de9d9-7cf4-4f02-b619-c6032408f50a", "5", "AdminId" },
                    { "f3e9b2e1-3ae7-4c95-8e3c-82bd9af31fa6", "15", "HomeOwnerId" },
                    { "f4766bb8-dce8-4821-b309-7efb232ed402", "4", "AdminId" },
                    { "f5c485c7-195a-4954-9885-c549f2663d43", "1", "AdminId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0757278c-5a40-4072-929c-f428af27d92a", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "33f95c89-fbf6-4c2e-87c2-c931ccf75a21", "AdminId", "SeedAdminId" },
                    { "d7c5e9b0-59f2-4bea-8540-a70151a24fb0", "CompanyOwnerId", "SeedCompanyOwnerId" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "0fe9f137-804d-422d-9523-8fb200875db8");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "19cc6758-ae2e-44cb-b7df-95990d44c676");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "34894d8e-a618-4655-be1b-6969835662cc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3d9a7a71-acfb-484c-b39e-70a0dc13d18a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3ef96c9b-706e-467e-b12a-82b1202dbd99");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "47be7b51-b757-4728-bffc-cc8de299a53d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5119448f-3210-45c0-b8eb-a867b9961d0d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5952af66-6ffe-4c3b-ad99-4fcb82a383b4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6c068b64-874e-4d71-972d-fcb2e2a69bbf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "81e6cac6-217b-4aee-8299-1e86912cbbf6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "90a78fab-3d3a-4dbf-9fd3-6201b01bdb43");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "92759e0c-7632-4d29-bcf0-7339f9e10950");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9a8c9d73-8083-4aae-89c8-04b1a848bd23");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "9cbc4a29-9a87-4c11-b677-beb791c51eab");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a7d0c17d-f174-463b-831f-56f56f26ccd7");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "cc6de9d9-7cf4-4f02-b619-c6032408f50a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f3e9b2e1-3ae7-4c95-8e3c-82bd9af31fa6");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f4766bb8-dce8-4821-b309-7efb232ed402");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "f5c485c7-195a-4954-9885-c549f2663d43");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "0757278c-5a40-4072-929c-f428af27d92a");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "33f95c89-fbf6-4c2e-87c2-c931ccf75a21");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: "d7c5e9b0-59f2-4bea-8540-a70151a24fb0");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "03ad2fe6-1507-4695-a56a-72c069b130d4", "17", "HomeOwnerId" },
                    { "15eb0103-71bf-4c61-b60d-0c1b27ac4a47", "11", "HomeOwnerId" },
                    { "231e51cd-ce64-445d-9f1f-1a1b9e9ee452", "18", "HomeOwnerId" },
                    { "38ed22ee-73ff-4902-9104-37aab0a3498f", "9", "HomeOwnerId" },
                    { "3a482be9-5c43-417c-a376-8a6862af2a1d", "8", "CompanyOwnerId" },
                    { "7e00431f-8113-48a9-a6ce-d8baea957aa2", "1", "AdminId" },
                    { "80d08fc6-059f-4470-a57d-fdc5c7f46155", "2", "AdminId" },
                    { "8d39ac80-9185-4b07-990e-ff46de2f6835", "5", "AdminId" },
                    { "93010585-450c-4fb7-8863-b9aff7a208d9", "16", "HomeOwnerId" },
                    { "a13f27f8-c609-438d-9f4c-ab2b1c0420d0", "14", "HomeOwnerId" },
                    { "a24fe266-78ef-4d31-92fd-c77e56dbb44e", "15", "HomeOwnerId" },
                    { "a51c131e-7a5c-4744-9aba-ea88f5748d6b", "13", "HomeOwnerId" },
                    { "a94cf882-0010-412b-835b-ded792f7fa9c", "3", "AdminId" },
                    { "b1885178-bc39-4361-a9bc-3b48454dea80", "12", "HomeOwnerId" },
                    { "b3395568-dcea-4dfe-b7f9-2edbe193dc72", "7", "CompanyOwnerId" },
                    { "b82f79c2-26f5-4ae9-90ed-55726be1c3a2", "6", "CompanyOwnerId" },
                    { "ba9198eb-7df8-4ccf-8054-10080ce31ff8", "4", "AdminId" },
                    { "c47909d3-fb55-4f2f-87a4-9234a0bc94f5", "19", "HomeOwnerId" },
                    { "c8bfe1c9-c9b2-4f42-9dc9-804e39f23679", "10", "HomeOwnerId" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4431a628-9851-4c38-a216-e62c6ddcd475", "HomeOwnerId", "SeedHomeOwnerId" },
                    { "a47c8454-9928-4197-b5f8-7c4423b597a1", "CompanyOwnerId", "SeedCompanyOwnerId" },
                    { "c2c861d8-562a-4693-99c7-66d5e30ec390", "AdminId", "SeedAdminId" }
                });
        }
    }
}
