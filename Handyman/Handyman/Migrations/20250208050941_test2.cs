using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3980), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3986), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 11, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3939), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3946), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3952), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3953), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4045), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4044), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4053), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4051), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3620), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3629), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3633), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3634) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3637), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3638) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3903), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3909), new DateTime(2025, 2, 8, 4, 58, 52, 596, DateTimeKind.Utc).AddTicks(3910) });
        }
    }
}
