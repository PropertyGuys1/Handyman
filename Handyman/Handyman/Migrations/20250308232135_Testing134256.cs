using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class Testing134256 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2635), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2637), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2683), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2682), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2683) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2686), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2686), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2687) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { false, new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2046), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { false, new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2051), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2051) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { false, new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2053), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2053) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { false, new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2055), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2569), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2569) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2572), new DateTime(2025, 3, 8, 23, 21, 34, 846, DateTimeKind.Utc).AddTicks(2572) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Profiles");

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4316), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4325), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4461), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4459), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4462) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4472), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4470), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2818), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2832), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2839), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2845), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(2847) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4021), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4023) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4030), new DateTime(2025, 3, 7, 18, 1, 42, 393, DateTimeKind.Utc).AddTicks(4032) });
        }
    }
}
