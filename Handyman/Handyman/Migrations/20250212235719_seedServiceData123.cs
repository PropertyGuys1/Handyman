using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class seedServiceData123 : Migration
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
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
                table: "Profiles",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "Password", "PhoneNumber", "Role", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown, USA", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7663), "john.doe@example.com", "John Doe", "jhon123", "123-456-7890", "Customer", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7667), "customer1" },
                    { 2, "456 Elm St, Othertown, USA", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7670), "jane.smith@example.com", "Jane Smith", "jane123", "987-654-3210", "Customer", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7670), "customer2" },
                    { 3, "789 Oak St, Sometown, USA", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7672), "mike.johnson@example.com", "Mike Johnson", "mike123", "555-123-4567", "Provider", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7673), "provider1" },
                    { 4, "321 Pine St, Anothertown, USA", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7675), "emily.davis@example.com", "Emily Davis", "emily123", "555-987-6543", "Provider", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(7675), "provider2" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Description", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Most commonly requested services.", null, false, "Popular Tasks" },
                    { 2, "Handpicked services for special needs.", null, false, "Featured Tasks" },
                    { 3, "General handyman and repair services.", null, false, "Handyman Services" },
                    { 4, "Services for helping with moving and hauling.", null, false, "Moving Services" },
                    { 5, "Services related to holiday preparations.", null, false, "Holiday Help" },
                    { 6, "Services for assembling furniture.", null, false, "Furniture Assembly" },
                    { 7, "Services for winter-related tasks.", null, false, "Winter Tasks" },
                    { 8, "Services for lawn and garden care.", null, false, "Yard Work" },
                    { 9, "Cleaning and disinfecting services.", null, false, "Cleaning" },
                    { 10, "Services related to shopping and delivery.", null, false, "Shopping & Delivery" },
                    { 11, "Services that can be performed contactlessly.", null, false, "Contactless Tasks" },
                    { 12, "Services related to IKEA products.", null, false, "IKEA Services" },
                    { 13, "Mounting and installation tasks.", null, false, "Mounting & Installation" }
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
                columns: new[] { "Id", "Cost", "Description", "IsDeleted", "Name", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, null, null, false, "Yardwork", 1 },
                    { 2, null, null, false, "Minor Home Repair", 1 },
                    { 3, null, null, false, "Furniture Assembly", 1 },
                    { 4, null, null, false, "Snow Removal", 1 },
                    { 5, null, null, false, "TV Mounting", 1 },
                    { 6, null, null, false, "Help Moving", 1 },
                    { 7, null, null, false, "Handyman", 1 },
                    { 8, null, null, false, "Painting", 1 },
                    { 9, null, null, false, "Lighting Installation", 1 },
                    { 10, null, null, false, "Hang Pictures", 1 },
                    { 11, null, null, false, "IKEA Services", 1 },
                    { 12, null, null, false, "Delivery", 2 },
                    { 13, null, null, false, "Home Repairs", 2 },
                    { 14, null, null, false, "General Cleaning", 2 },
                    { 15, null, null, false, "Assemble Furniture", 2 },
                    { 16, null, null, false, "Help Moving / Hauling", 2 },
                    { 17, null, null, false, "Heavy Lifting", 2 },
                    { 18, null, null, false, "Personal Assistant", 2 },
                    { 19, null, null, false, "Yard Work", 2 },
                    { 20, null, null, false, "Queue in Line", 2 },
                    { 21, null, null, false, "Organize Closet", 2 },
                    { 22, null, null, false, "Office Administration", 2 },
                    { 23, null, null, false, "Organization", 2 },
                    { 24, null, null, false, "Home Repairs", 3 },
                    { 25, null, null, false, "Assemble Furniture", 3 },
                    { 26, null, null, false, "TV Mounting", 3 },
                    { 27, null, null, false, "Heavy Lifting", 3 },
                    { 28, null, null, false, "Painting", 3 },
                    { 29, null, null, false, "Plumbing", 3 },
                    { 30, null, null, false, "Yard Work", 3 },
                    { 31, null, null, false, "Hang Pictures", 3 },
                    { 32, null, null, false, "Shelf Mounting", 3 },
                    { 33, null, null, false, "Light Installation", 3 },
                    { 34, null, null, false, "Electrical Work", 3 },
                    { 35, null, null, false, "Carpentry", 3 },
                    { 36, null, null, false, "Baby Proofing", 3 },
                    { 37, null, null, false, "Smart Home Installation", 3 },
                    { 38, null, null, false, "Help Moving / Hauling", 4 },
                    { 39, null, null, false, "One Item Movers", 4 },
                    { 40, null, null, false, "Furniture Movers", 4 },
                    { 41, null, null, false, "Junk Removal", 4 },
                    { 42, null, null, false, "Full Service Movers", 4 },
                    { 43, null, null, false, "Packing and Moving Services", 4 },
                    { 44, null, null, false, "Unpacking Services", 4 },
                    { 45, null, null, false, "Heavy Lifting", 4 },
                    { 46, null, null, false, "Furniture Removal", 4 },
                    { 47, null, null, false, "Couch Removal", 4 },
                    { 48, null, null, false, "Move Furniture Up/Downstairs", 4 },
                    { 49, null, null, false, "Hang Christmas Lights", 5 },
                    { 50, null, null, false, "Christmas Tree Delivery", 5 },
                    { 51, null, null, false, "Christmas Decorating", 5 },
                    { 52, null, null, false, "Shopping", 5 },
                    { 53, null, null, false, "Holiday Shopping", 5 },
                    { 54, null, null, false, "Gifts Wrapping", 5 },
                    { 55, null, null, false, "Grocery Shopping", 5 },
                    { 56, null, null, false, "Gift Shopping", 5 },
                    { 57, null, null, false, "Furniture Assembly", 6 },
                    { 58, null, null, false, "IKEA Furniture Assembly", 6 },
                    { 59, null, null, false, "Assembly of Kids Furniture", 6 },
                    { 60, null, null, false, "Office Furniture Assembly", 6 },
                    { 61, null, null, false, "Shed Assembly", 6 },
                    { 62, null, null, false, "Snow Removal", 7 },
                    { 63, null, null, false, "Ice Melting", 7 },
                    { 64, null, null, false, "Winterizing Property", 7 },
                    { 65, null, null, false, "Gutter Cleaning", 7 },
                    { 66, null, null, false, "Shoveling Driveways", 7 },
                    { 67, null, null, false, "Winterizing Plumbing", 7 },
                    { 68, null, null, false, "Lawn Care", 8 },
                    { 69, null, null, false, "Tree Pruning", 8 },
                    { 70, null, null, false, "Leaf Raking", 8 },
                    { 71, null, null, false, "Lawn Mowing", 8 },
                    { 72, null, null, false, "Gardening", 8 },
                    { 73, null, null, false, "Mulching", 8 },
                    { 74, null, null, false, "Deep Cleaning", 9 },
                    { 75, null, null, false, "Office Cleaning", 9 },
                    { 76, null, null, false, "Carpet Cleaning", 9 },
                    { 77, null, null, false, "Window Cleaning", 9 },
                    { 78, null, null, false, "Move-In/Move-Out Cleaning", 9 },
                    { 79, null, null, false, "Pressure Washing", 9 },
                    { 80, null, null, false, "Post-Construction Cleaning", 9 },
                    { 81, null, null, false, "Grocery Shopping", 10 },
                    { 82, null, null, false, "Gift Shopping", 10 },
                    { 83, null, null, false, "Package Pickup & Delivery", 10 },
                    { 84, null, null, false, "Personal Shopping Assistant", 10 },
                    { 85, null, null, false, "Errand Running", 10 },
                    { 86, null, null, false, "Contactless Grocery Shopping", 11 },
                    { 87, null, null, false, "Contactless Furniture Assembly", 11 },
                    { 88, null, null, false, "Contactless Delivery", 11 },
                    { 89, null, null, false, "Contactless Cleaning", 11 },
                    { 90, null, null, false, "IKEA Furniture Assembly", 12 },
                    { 91, null, null, false, "IKEA Pickup & Delivery", 12 },
                    { 92, null, null, false, "IKEA Home Installation", 12 },
                    { 93, null, null, false, "TV Mounting", 13 },
                    { 94, null, null, false, "Picture Hanging", 13 },
                    { 95, null, null, false, "Shelving Installation", 13 },
                    { 96, null, null, false, "Light Fixture Installation", 13 },
                    { 97, null, null, false, "Curtain Rod Installation", 13 }
                });

            migrationBuilder.InsertData(
                table: "ProviderServices",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Notes", "ProviderProfileId", "ServiceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8280), "https://example.com/images/lawn_mowing.jpg", "Experienced in lawn mowing with professional equipment.", 1, 1, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8280) },
                    { 2, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8282), "https://example.com/images/house_cleaning.jpg", "Thorough house cleaning services with eco-friendly products.", 2, 3, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8283) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreatedAt", "CustomerNote", "CustomerProfileId", "IsApproved", "ProviderServiceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 15, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8319), new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8327), "Please make sure to trim the edges.", 1, false, 1, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8328) },
                    { 2, new DateTime(2025, 2, 17, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8330), new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8332), "Focus on the kitchen and living room.", 2, false, 2, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8332) }
                });

            migrationBuilder.InsertData(
                table: "AppointmentFeedbacks",
                columns: new[] { "Id", "AppointmentId", "CreatedAt", "CustomerProfileId", "Feedback", "IsApproved", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8368), 1, "Great service! Very satisfied.", false, 5, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8369) },
                    { 2, 2, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8371), 2, "Good job, but could be more thorough.", false, 4, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8372) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "AppointmentId", "CreatedAt", "CustomerProfileId", "IsSuccessful", "PaymentDate", "PaymentMethod", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 50.00m, 1, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8470), 1, true, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8469), "Credit Card", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8470) },
                    { 2, 75.00m, 2, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8473), 2, true, new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8473), "PayPal", new DateTime(2025, 2, 12, 23, 57, 15, 795, DateTimeKind.Utc).AddTicks(8474) }
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
