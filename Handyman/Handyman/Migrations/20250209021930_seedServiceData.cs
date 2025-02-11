using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class seedServiceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_UserProfiles_UserProfileUserId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("2f65b350-0ace-43e4-9fd4-4c3b2d25fdf9"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("4e12033b-3e5c-4ed1-843e-7b05e3fffe7e"));

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_Service_UserProfileUserId",
                table: "Services",
                newName: "IX_Services_UserProfileUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "Location", "ServiceDateTime", "ServiceId", "Status", "UpdatedDate", "Urgent" },
                values: new object[,]
                {
                    { new Guid("914d9da7-f30f-4aad-9a24-26de410ec52f"), new DateTime(2025, 2, 8, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5103), "john_d", "456 Elm Street, City", new DateTime(2025, 2, 13, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5101), new Guid("ef8cb068-0cb1-4bfb-91a0-0c9b058ea470"), "Pending", new DateTime(2025, 2, 8, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5104), true },
                    { new Guid("fe408a41-92b1-43ec-842d-f3de2ad5045d"), new DateTime(2025, 2, 8, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5094), "john_d", "123 Main Street, City", new DateTime(2025, 2, 10, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5088), new Guid("33375157-ebe7-4480-8d1e-6b8a6378cab2"), "Scheduled", new DateTime(2025, 2, 8, 21, 19, 29, 434, DateTimeKind.Local).AddTicks(5095), false }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Catagory", "Cost", "Description", "IsDeleted", "Name", "UserProfileUserId" },
                values: new object[,]
                {
                    { new Guid("25f6d3e2-48b7-4c71-b480-82e358a987d0"), "Electrical", 200.00m, "Installation and repair of home electrical systems.", false, "Electrical Wiring", null },
                    { new Guid("7f0fbc16-5ed4-4109-9dcf-87182b829921"), "Plumbing", 150.00m, "Fixing leaks and installing new plumbing fixtures.", false, "Plumbing Repair", null },
                    { new Guid("b644dd8d-cdbc-495b-8b07-664c1a8f23fb"), "Carpentry", 180.00m, "Custom furniture, doors, and wooden structures.", false, "Carpentry Work", null },
                    { new Guid("f0e20d39-4262-41e4-acd4-437e0021d91a"), "HVAC", 250.00m, "Heating, ventilation, and AC system servicing.", false, "HVAC Maintenance", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Services_UserProfiles_UserProfileUserId",
                table: "Services",
                column: "UserProfileUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_UserProfiles_UserProfileUserId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("914d9da7-f30f-4aad-9a24-26de410ec52f"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("fe408a41-92b1-43ec-842d-f3de2ad5045d"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("25f6d3e2-48b7-4c71-b480-82e358a987d0"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("7f0fbc16-5ed4-4109-9dcf-87182b829921"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("b644dd8d-cdbc-495b-8b07-664c1a8f23fb"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f0e20d39-4262-41e4-acd4-437e0021d91a"));

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameIndex(
                name: "IX_Services_UserProfileUserId",
                table: "Service",
                newName: "IX_Service_UserProfileUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "Location", "ServiceDateTime", "ServiceId", "Status", "UpdatedDate", "Urgent" },
                values: new object[,]
                {
                    { new Guid("2f65b350-0ace-43e4-9fd4-4c3b2d25fdf9"), new DateTime(2025, 2, 8, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2451), "john_d", "123 Main Street, City", new DateTime(2025, 2, 10, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2444), new Guid("574c35f8-1950-4a4d-8e8f-51331557abbd"), "Scheduled", new DateTime(2025, 2, 8, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2454), false },
                    { new Guid("4e12033b-3e5c-4ed1-843e-7b05e3fffe7e"), new DateTime(2025, 2, 8, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2490), "john_d", "456 Elm Street, City", new DateTime(2025, 2, 13, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2482), new Guid("ad43fc81-62ab-4d22-9f88-ba3ddb1da39a"), "Pending", new DateTime(2025, 2, 8, 19, 41, 14, 46, DateTimeKind.Local).AddTicks(2496), true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Service_UserProfiles_UserProfileUserId",
                table: "Service",
                column: "UserProfileUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
