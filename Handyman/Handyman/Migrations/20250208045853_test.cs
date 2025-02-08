using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "provider1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "provider2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5701), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5704), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 11, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5671), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5677), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppointmentDate", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 13, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5680), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5681), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5681) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "customer1", 0, "e33cf89a-2084-466f-8550-cbc7f0475408", "john.doe@example.com", true, false, null, "JOHN.DOE@EXAMPLE.COM", "CUSTOMER1", "AQAAAAIAAYagAAAAEFY6HTHTy94SKOFtNjwzfa9XXeIFxfbAFkB/IabhNkBpclFWBjcl9zjdV1kIkzX1OQ==", null, false, "fa925476-3312-4638-83ff-3f34624c67d4", false, "customer1" },
                    { "customer2", 0, "1aa3be8e-f718-43b5-bae8-d22f90f1ec73", "jane.smith@example.com", true, false, null, "JANE.SMITH@EXAMPLE.COM", "CUSTOMER2", "AQAAAAIAAYagAAAAENbi7leMIp8Vvz7wEHGqkZ6rGg2WYo4okBLG5Pr9RLVW5aEZRrMA8NKmjwCeucArDA==", null, false, "9265c83e-5d06-4510-811a-ede894f8d884", false, "customer2" },
                    { "provider1", 0, "751f8a4b-20f1-4bad-a4a3-a53b39c00a06", "mike.johnson@example.com", true, false, null, "MIKE.JOHNSON@EXAMPLE.COM", "PROVIDER1", "AQAAAAIAAYagAAAAEPxPVITFxtG6ixqCbNsXJUAu3gqGhAHqIwM19l87dQfcm+PapXEO8aYjn0DmX3r4eQ==", null, false, "9c07b745-b093-4df1-9881-4d8d9f4c932e", false, "provider1" },
                    { "provider2", 0, "f647aad7-23df-4640-b06e-4ddd8c410a2f", "emily.davis@example.com", true, false, null, "EMILY.DAVIS@EXAMPLE.COM", "PROVIDER2", "AQAAAAIAAYagAAAAEIZ1bGhBchgrM6IqYZZj+mMW9fKnPytqbV4tIiY7DQZ5VJSHpmRT0z6olq8VOrgjDg==", null, false, "9e81d219-38b5-401a-9227-f6b10ccc970c", false, "provider2" }
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5746), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5745), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5749), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5749), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5467), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5477), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5479), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5481), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5647), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5650), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5650) });
        }
    }
}
