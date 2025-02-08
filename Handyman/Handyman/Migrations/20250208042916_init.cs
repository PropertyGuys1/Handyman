using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Preferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    ServicesOffered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderProfileId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderServices_ProviderProfiles_ProviderProfileId",
                        column: x => x.ProviderProfileId,
                        principalTable: "ProviderProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_ProviderServices_ProviderServiceId",
                        column: x => x.ProviderServiceId,
                        principalTable: "ProviderServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentFeedbacks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentFeedbacks_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Anytown", "USA", "12345", "CA", "123 Main St" },
                    { 2, "Othertown", "USA", "67890", "NY", "456 Elm St" }
                });

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

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "PhoneNumber", "Role", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5467), "john.doe@example.com", "John Doe", "123-456-7890", "Customer", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5473), "customer1" },
                    { 2, "456 Elm St, Othertown, USA", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5477), "jane.smith@example.com", "Jane Smith", "987-654-3210", "Customer", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5478), "customer2" },
                    { 3, "789 Oak St, Sometown, USA", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5479), "mike.johnson@example.com", "Mike Johnson", "555-123-4567", "Provider", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5480), "provider1" },
                    { 4, "321 Pine St, Anothertown, USA", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5481), "emily.davis@example.com", "Emily Davis", "555-987-6543", "Provider", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5481), "provider2" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Services related to lawn maintenance and care.", false, "Lawn Care" },
                    { 2, "Services related to cleaning and maintaining the house.", false, "House Cleaning" },
                    { 3, "Services related to plumbing and pipe maintenance.", false, "Plumbing" }
                });

            migrationBuilder.InsertData(
                table: "CustomerProfiles",
                columns: new[] { "Id", "AddressId", "Preferences", "ProfileId" },
                values: new object[,]
                {
                    { 1, 1, "Weekly lawn mowing", 1 },
                    { 2, 2, "Monthly house cleaning", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProviderProfiles",
                columns: new[] { "Id", "Availability", "ProfileId", "Rating", "ServicesOffered" },
                values: new object[,]
                {
                    { 1, "Mon-Fri 9am-5pm", 3, 4.5m, "Lawn Mowing, Hedge Trimming" },
                    { 2, "Sat-Sun 10am-4pm", 4, 4.8m, "House Cleaning, Carpet Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IsDeleted", "Name", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, false, "Lawn Mowing", 1 },
                    { 2, false, "Hedge Trimming", 1 },
                    { 3, false, "House Cleaning", 2 },
                    { 4, false, "Carpet Cleaning", 2 },
                    { 5, false, "Pipe Repair", 3 },
                    { 6, false, "Leak Detection", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProviderServices",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Notes", "ProviderProfileId", "ServiceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5647), "https://example.com/images/lawn_mowing.jpg", "Experienced in lawn mowing with professional equipment.", 1, 1, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5647) },
                    { 2, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5650), "https://example.com/images/house_cleaning.jpg", "Thorough house cleaning services with eco-friendly products.", 2, 3, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5650) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedAt", "CustomerNote", "CustomerProfileId", "IsApproved", "ProviderServiceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 11, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5671), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5677), "Please make sure to trim the edges.", 1, false, 1, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5677) },
                    { 2, new DateTime(2025, 2, 13, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5680), new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5681), "Focus on the kitchen and living room.", 2, false, 2, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5681) }
                });

            migrationBuilder.InsertData(
                table: "AppointmentFeedbacks",
                columns: new[] { "Id", "AppointmentId", "CreatedAt", "CustomerProfileId", "Feedback", "IsApproved", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5701), 1, "Great service! Very satisfied.", false, 5, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5701) },
                    { 2, 2, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5704), 2, "Good job, but could be more thorough.", false, 4, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5704) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "AppointmentId", "CreatedAt", "CustomerProfileId", "IsSuccessful", "PaymentDate", "PaymentMethod", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 50.00m, 1, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5746), 1, true, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5745), "Credit Card", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5746) },
                    { 2, 75.00m, 2, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5749), 2, true, new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5749), "PayPal", new DateTime(2025, 2, 8, 4, 29, 15, 747, DateTimeKind.Utc).AddTicks(5750) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentFeedbacks_AppointmentId",
                table: "AppointmentFeedbacks",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentFeedbacks_CustomerProfileId",
                table: "AppointmentFeedbacks",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerProfileId",
                table: "Appointments",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProviderServiceId",
                table: "Appointments",
                column: "ProviderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_AddressId",
                table: "CustomerProfiles",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_ProfileId",
                table: "CustomerProfiles",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerProfileId",
                table: "Payments",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderProfiles_ProfileId",
                table: "ProviderProfiles",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProviderServices_ProviderProfileId",
                table: "ProviderServices",
                column: "ProviderProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderServices_ServiceId",
                table: "ProviderServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentFeedbacks");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "ProviderServices");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ProviderProfiles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
