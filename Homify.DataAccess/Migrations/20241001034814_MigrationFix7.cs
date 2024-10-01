using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "02ce136c-f685-4680-8d39-5d7a2957df91");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "08388a84-d460-41fc-9e00-a90507776347");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "223b54fc-1abe-42de-b27b-c2e5761dadb1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "27a676ed-719d-465d-80c4-a610a8838073");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2d656370-43f7-4fdd-aa6d-b49def81e285");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "2e391f01-12dd-4805-a77c-75364b6fbdfe");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "30acfcf6-3b14-49c1-8e7c-0ae867c8de6f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3b828dc8-5c29-43dd-8968-ffdf11e3c94e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "691ba517-4f39-47bc-9f90-d2e65d6785cc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "776eee40-b634-4e7b-b7b5-ebbf7be5e7ad");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8a3fd5dd-ac83-4767-b016-2dd8157383cb");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "96278c12-9e5d-43fb-b547-59eb45b9bdad");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ba92212e-cc9a-4429-9f39-d6d77283275e");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "c24ead45-096f-45eb-af96-76b384307d39");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d3043ec6-548a-4203-8519-20cee3c66d4d");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d7d718f9-3264-4cf7-9504-8ae895510239");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d91e9122-58a6-4b67-a725-2c8338a05e36");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "eabe4340-fec1-4698-b2bb-31b6cb9da251");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fcb30824-3350-4e62-9c5e-dca39939b64d");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "314c2256-afe4-4423-98cc-485d23cca118", "4", "adminid" },
                    { "3258e9ac-1b5b-4fb4-af10-116b274ed7be", "10", "homeownerId" },
                    { "493e5c82-4b46-45aa-a2d6-682dee65b3cf", "13", "homeownerId" },
                    { "4ecebe7b-92ae-4c81-bb04-fa54c61cac1b", "5", "adminid" },
                    { "5166852f-bb08-4716-82f2-0e111df6581f", "9", "homeownerId" },
                    { "51e98391-14c4-4466-aa8a-bc2039acc5f2", "7", "companyownerId" },
                    { "63ebb058-0960-4734-8bb7-6b0b90ab4585", "19", "homeownerId" },
                    { "6fbedf7f-8867-4198-8603-5ab3eb6c8123", "2", "adminid" },
                    { "7f28a5f2-f237-4a1b-b7a7-3bc46cd94ec1", "15", "homeownerId" },
                    { "847a393a-1f02-4c55-9887-aa59b3fc14fd", "14", "homeownerId" },
                    { "8a1ccc7d-3020-4d39-888b-525f09f0e7e5", "6", "companyownerId" },
                    { "910659a7-ed8d-4803-ad5c-99497b0b63ac", "8", "companyownerId" },
                    { "a991b4af-5118-41a3-9874-785ec6093b56", "18", "homeownerId" },
                    { "d85495e5-3bf6-4972-b2a4-c7a16bbb0c6a", "11", "homeownerId" },
                    { "deb2fa6a-7195-498c-bea8-fe6a55ba0bb4", "3", "adminid" },
                    { "e9521cd0-4263-43a9-a650-f4104e3afc2a", "17", "homeownerId" },
                    { "e9bd3436-0c07-4d6e-a3d5-e4b0bb5c99ce", "16", "homeownerId" },
                    { "ea005149-1835-4671-b88a-da9faa7ff9dc", "1", "adminid" },
                    { "fafa9cd6-0df5-4fac-9ecc-94ffe9f17764", "12", "homeownerId" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "314c2256-afe4-4423-98cc-485d23cca118");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "3258e9ac-1b5b-4fb4-af10-116b274ed7be");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "493e5c82-4b46-45aa-a2d6-682dee65b3cf");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "4ecebe7b-92ae-4c81-bb04-fa54c61cac1b");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "5166852f-bb08-4716-82f2-0e111df6581f");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "51e98391-14c4-4466-aa8a-bc2039acc5f2");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "63ebb058-0960-4734-8bb7-6b0b90ab4585");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "6fbedf7f-8867-4198-8603-5ab3eb6c8123");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "7f28a5f2-f237-4a1b-b7a7-3bc46cd94ec1");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "847a393a-1f02-4c55-9887-aa59b3fc14fd");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "8a1ccc7d-3020-4d39-888b-525f09f0e7e5");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "910659a7-ed8d-4803-ad5c-99497b0b63ac");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "a991b4af-5118-41a3-9874-785ec6093b56");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "d85495e5-3bf6-4972-b2a4-c7a16bbb0c6a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "deb2fa6a-7195-498c-bea8-fe6a55ba0bb4");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e9521cd0-4263-43a9-a650-f4104e3afc2a");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "e9bd3436-0c07-4d6e-a3d5-e4b0bb5c99ce");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "ea005149-1835-4671-b88a-da9faa7ff9dc");

            migrationBuilder.DeleteData(
                table: "RoleSystemPermissions",
                keyColumn: "RoleSystemPermissionId",
                keyValue: "fafa9cd6-0df5-4fac-9ecc-94ffe9f17764");

            migrationBuilder.InsertData(
                table: "RoleSystemPermissions",
                columns: new[] { "RoleSystemPermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "02ce136c-f685-4680-8d39-5d7a2957df91", "4", "adminid" },
                    { "08388a84-d460-41fc-9e00-a90507776347", "16", "homeownerId" },
                    { "223b54fc-1abe-42de-b27b-c2e5761dadb1", "11", "homeownerId" },
                    { "27a676ed-719d-465d-80c4-a610a8838073", "1", "adminid" },
                    { "2d656370-43f7-4fdd-aa6d-b49def81e285", "17", "homeownerId" },
                    { "2e391f01-12dd-4805-a77c-75364b6fbdfe", "2", "adminid" },
                    { "30acfcf6-3b14-49c1-8e7c-0ae867c8de6f", "19", "homeownerId" },
                    { "3b828dc8-5c29-43dd-8968-ffdf11e3c94e", "18", "homeownerId" },
                    { "691ba517-4f39-47bc-9f90-d2e65d6785cc", "8", "companyownerId" },
                    { "776eee40-b634-4e7b-b7b5-ebbf7be5e7ad", "5", "adminid" },
                    { "8a3fd5dd-ac83-4767-b016-2dd8157383cb", "7", "companyownerId" },
                    { "96278c12-9e5d-43fb-b547-59eb45b9bdad", "10", "homeownerId" },
                    { "ba92212e-cc9a-4429-9f39-d6d77283275e", "13", "homeownerId" },
                    { "c24ead45-096f-45eb-af96-76b384307d39", "9", "homeownerId" },
                    { "d3043ec6-548a-4203-8519-20cee3c66d4d", "15", "homeownerId" },
                    { "d7d718f9-3264-4cf7-9504-8ae895510239", "14", "homeownerId" },
                    { "d91e9122-58a6-4b67-a725-2c8338a05e36", "6", "companyownerId" },
                    { "eabe4340-fec1-4698-b2bb-31b6cb9da251", "3", "adminid" },
                    { "fcb30824-3350-4e62-9c5e-dca39939b64d", "12", "homeownerId" }
                });
        }
    }
}
