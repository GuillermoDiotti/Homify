using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Homify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwners_Companies_Id",
                table: "CompanyOwners");

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

            migrationBuilder.AddColumn<string>(
                name: "HomeId",
                table: "HomeOwners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyOwners_OwnerId",
                table: "Companies",
                column: "OwnerId",
                principalTable: "CompanyOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyOwners_OwnerId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners");

            migrationBuilder.DropIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OwnerId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeOwners");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Companies");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwners_Companies_Id",
                table: "CompanyOwners",
                column: "Id",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
