using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class nullableprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1812), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1815), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 11, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1788), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1793), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1795), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1796), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1847), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1846), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1851), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1851), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1628), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1629) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1632), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1634), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1636), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1769), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1772), new DateTime(2025, 2, 8, 14, 6, 37, 376, DateTimeKind.Utc).AddTicks(1772) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8281), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8287), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8288) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 11, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8252), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8257), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8262), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8263), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8330), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8329), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8335), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8334), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8021), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8027), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8029), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8032), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8225), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8230), new DateTime(2025, 2, 8, 5, 9, 40, 445, DateTimeKind.Utc).AddTicks(8231) });
        }
    }
}
