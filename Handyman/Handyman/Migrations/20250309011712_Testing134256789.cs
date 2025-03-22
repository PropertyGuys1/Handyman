using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class Testing134256789 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7289), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7293), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7293) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7351), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7357), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7356), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { true, new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6628), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { true, new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6637), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6637) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { true, new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6640), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Active", "CreatedAt", "UpdatedAt" },
                values: new object[] { true, new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6642), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(6643) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7214), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7219), new DateTime(2025, 3, 9, 1, 17, 11, 224, DateTimeKind.Utc).AddTicks(7219) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
