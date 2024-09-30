using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PermissionsSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AuthToken",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Value", "RoleId" },
                values: new object[,]
                {
                    { "admins-AllAccounts", null },
                    { "admins-Create", null },
                    { "admins-Delete", null },
                    { "companies-Create", null },
                    { "companies-RegisterSensor", null },
                    { "companies-ViewSupported", null },
                    { "company-owners-Create", null },
                    { "devices-RegisterCamera", null },
                    { "devices-ViewRegistered", null },
                    { "homes-Create", null },
                    { "homes-NotificatedMembers", null },
                    { "homes-ObtainCompanies", null },
                    { "homes-ObtainHomeDevices", null },
                    { "homes-ObtainMembers", null },
                    { "homes-UpdateHomeDevice", null },
                    { "homes-UpdateMembersList", null },
                    { "notifications-Create", null },
                    { "notifications-ObtainNotifications", null },
                    { "notifications-UpdateNotification", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "admins-AllAccounts");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "admins-Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "admins-Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "companies-Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "companies-RegisterSensor");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "companies-ViewSupported");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "company-owners-Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "devices-RegisterCamera");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "devices-ViewRegistered");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-NotificatedMembers");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-ObtainCompanies");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-ObtainHomeDevices");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-ObtainMembers");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-UpdateHomeDevice");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "homes-UpdateMembersList");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "notifications-Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "notifications-ObtainNotifications");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Value",
                keyValue: "notifications-UpdateNotification");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthToken",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
