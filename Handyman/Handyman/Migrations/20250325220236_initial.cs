using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
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
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AddressCustomerProfile",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomerProfile", x => new { x.AddressesId, x.CustomerProfileId });
                    table.ForeignKey(
                        name: "FK_AddressCustomerProfile_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressCustomerProfile_CustomerProfiles_CustomerProfileId",
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id");
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
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerProfileId = table.Column<int>(type: "int", nullable: true),
                    ProviderServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_CustomerProfiles_CustomerProfileId",
                        column: x => x.CustomerProfileId,
                        principalTable: "CustomerProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_ProviderServices_ProviderServiceId",
                        column: x => x.ProviderServiceId,
                        principalTable: "ProviderServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Active", "Address", "CreatedAt", "Email", "FullName", "Password", "PhoneNumber", "ProfileImage", "Role", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, true, "123 Main St, Anytown, USA", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2261), "john.doe@example.com", "John Doe", "jhon123", "123-456-7890", null, "Customer", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2263), "customer1" },
                    { 2, true, "456 Elm St, Othertown, USA", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2267), "jane.smith@example.com", "Jane Smith", "jane123", "987-654-3210", null, "Customer", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2267), "customer2" },
                    { 3, true, "789 Oak St, Sometown, USA", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2269), "mike.johnson@example.com", "Mike Johnson", "mike123", "555-123-4567", null, "Provider", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2270), "provider1" },
                    { 4, true, "321 Pine St, Anothertown, USA", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2271), "emily.davis@example.com", "Emily Davis", "emily123", "555-987-6543", null, "Provider", new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2272), "provider2" }
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
                    { 1, 50, "Lawn care, landscaping, and gardening tasks.", false, "Yardwork", 1 },
                    { 2, 75, "Basic home repairs like fixing leaks and broken fixtures.", false, "Minor Home Repair", 1 },
                    { 3, 100, "Assembling furniture from flat-pack kits.", false, "Furniture Assembly", 1 },
                    { 4, 60, "Clearing snow from driveways, walkways, and roofs.", false, "Snow Removal", 1 },
                    { 5, 120, "Mounting your TV on the wall for a clean look.", false, "TV Mounting", 1 },
                    { 6, 80, "Assisting with moving furniture or boxes.", false, "Help Moving", 1 },
                    { 7, 90, "General home repairs and maintenance tasks.", false, "Handyman", 1 },
                    { 8, 150, "Interior and exterior painting services.", false, "Painting", 1 },
                    { 9, 100, "Installing light fixtures and bulbs.", false, "Lighting Installation", 1 },
                    { 10, 50, "Hanging artwork or pictures on walls.", false, "Hang Pictures", 1 },
                    { 11, 100, "Assembly and delivery of IKEA furniture.", false, "IKEA Services", 1 },
                    { 12, 60, "Deliver packages or goods to your location.", false, "Delivery", 2 },
                    { 13, 120, "General home repair services like plumbing, electrical work, etc.", false, "Home Repairs", 2 },
                    { 14, 80, "Basic home or office cleaning services.", false, "General Cleaning", 2 },
                    { 15, 90, "Assembling furniture like desks, chairs, or tables.", false, "Assemble Furniture", 2 },
                    { 16, 100, "Help with moving or hauling large items.", false, "Help Moving / Hauling", 2 },
                    { 17, 80, "Lifting and transporting heavy objects.", false, "Heavy Lifting", 2 },
                    { 18, 100, "Personal errands and assistance for daily tasks.", false, "Personal Assistant", 2 },
                    { 19, 70, "Outdoor maintenance including lawn mowing and trimming.", false, "Yard Work", 2 },
                    { 20, 40, "Waiting in line for tickets, products, or services.", false, "Queue in Line", 2 },
                    { 21, 80, "Organizing your closet space for a more efficient setup.", false, "Organize Closet", 2 },
                    { 22, 90, "Office tasks like data entry, document management, etc.", false, "Office Administration", 2 },
                    { 23, 75, "Organizing personal spaces, offices, or garages.", false, "Organization", 2 },
                    { 24, 120, "General home repair services like plumbing, electrical work, etc.", false, "Home Repairs", 3 },
                    { 25, 90, "Assembling furniture like desks, chairs, or tables.", false, "Assemble Furniture", 3 },
                    { 26, 120, "Mounting your TV on the wall for a clean look.", false, "TV Mounting", 3 },
                    { 27, 80, "Lifting and transporting heavy objects.", false, "Heavy Lifting", 3 },
                    { 28, 150, "Interior and exterior painting services.", false, "Painting", 3 },
                    { 29, 130, "General plumbing repairs and installations.", false, "Plumbing", 3 },
                    { 30, 70, "Outdoor maintenance including lawn mowing and trimming.", false, "Yard Work", 3 },
                    { 31, 50, "Hanging artwork or pictures on walls.", false, "Hang Pictures", 3 },
                    { 32, 100, "Mounting shelves on walls for storage and decoration.", false, "Shelf Mounting", 3 },
                    { 33, 100, "Installing light fixtures and bulbs.", false, "Light Installation", 3 },
                    { 34, 150, "Electrical installations and repairs.", false, "Electrical Work", 3 },
                    { 35, 200, "Custom woodwork and carpentry services.", false, "Carpentry", 3 },
                    { 36, 80, "Child-proofing your home with safety measures.", false, "Baby Proofing", 3 },
                    { 37, 180, "Installation of smart devices like thermostats, cameras, etc.", false, "Smart Home Installation", 3 },
                    { 38, 100, "Help with moving or hauling large items.", false, "Help Moving / Hauling", 4 },
                    { 39, 75, "Moving a single item, like a couch or appliance.", false, "One Item Movers", 4 },
                    { 40, 150, "Moving large furniture from one location to another.", false, "Furniture Movers", 4 },
                    { 41, 80, "Removal and disposal of unwanted items or junk.", false, "Junk Removal", 4 },
                    { 42, 300, "Complete moving service, including packing, loading, and unloading.", false, "Full Service Movers", 4 },
                    { 43, 250, "Packing up your home and moving everything to your new location.", false, "Packing and Moving Services", 4 },
                    { 44, 150, "Unpacking boxes and organizing items in your new home.", false, "Unpacking Services", 4 },
                    { 45, 80, "Lifting and transporting heavy objects.", false, "Heavy Lifting", 4 },
                    { 46, 90, "Removal of old furniture that needs to be disposed of.", false, "Furniture Removal", 4 },
                    { 47, 75, "Removal of an old couch or sofa.", false, "Couch Removal", 4 },
                    { 48, 100, "Assisting in moving furniture up or down stairs.", false, "Move Furniture Up/Downstairs", 4 },
                    { 49, 120, "Decorating your home with Christmas lights.", false, "Hang Christmas Lights", 5 },
                    { 50, 80, "Delivery of a Christmas tree to your home.", false, "Christmas Tree Delivery", 5 },
                    { 51, 150, "Decorating your home for the holidays.", false, "Christmas Decorating", 5 },
                    { 52, 100, "Shopping for holiday gifts or groceries.", false, "Shopping", 5 },
                    { 53, 150, "Complete shopping for the holidays.", false, "Holiday Shopping", 5 },
                    { 54, 50, "Wrapping your holiday gifts.", false, "Gifts Wrapping", 5 },
                    { 55, 80, "Holiday grocery shopping.", false, "Grocery Shopping", 5 },
                    { 56, 100, "Shopping for holiday gifts.", false, "Gift Shopping", 5 },
                    { 57, 90, "Assembling furniture like desks, chairs, or tables.", false, "Furniture Assembly", 6 },
                    { 58, 100, "Assembling IKEA flat-pack furniture.", false, "IKEA Furniture Assembly", 6 },
                    { 59, 100, "Assembling kids furniture like cribs, dressers, etc.", false, "Assembly of Kids Furniture", 6 },
                    { 60, 120, "Assembling office furniture like desks and chairs.", false, "Office Furniture Assembly", 6 },
                    { 61, 150, "Assembling outdoor sheds or storage units.", false, "Shed Assembly", 6 },
                    { 62, 60, "Clearing snow from driveways, walkways, and roofs.", false, "Snow Removal", 7 },
                    { 63, 50, "Applying ice-melting substances to prevent slips and falls.", false, "Ice Melting", 7 },
                    { 64, 150, "Preparing your property for winter by sealing windows, pipes, etc.", false, "Winterizing Property", 7 },
                    { 65, 100, "Cleaning leaves and debris from gutters to prevent blockages.", false, "Gutter Cleaning", 7 },
                    { 66, 70, "Shoveling snow off driveways to ensure safe access.", false, "Shoveling Driveways", 7 },
                    { 67, 120, "Protecting pipes from freezing by insulating or draining them.", false, "Winterizing Plumbing", 7 },
                    { 68, 80, "Maintaining your lawn with mowing, fertilization, and watering.", false, "Lawn Care", 8 },
                    { 69, 120, "Trimming trees and removing dead branches for safety and appearance.", false, "Tree Pruning", 8 },
                    { 70, 60, "Raking and removing fallen leaves from yards and lawns.", false, "Leaf Raking", 8 },
                    { 71, 50, "Mowing your lawn to maintain a neat and healthy yard.", false, "Lawn Mowing", 8 },
                    { 72, 90, "Planting and caring for flowers, shrubs, and vegetable gardens.", false, "Gardening", 8 },
                    { 73, 100, "Applying mulch to garden beds to retain moisture and suppress weeds.", false, "Mulching", 8 },
                    { 74, 150, "Thorough cleaning of all surfaces, including hard-to-reach areas.", false, "Deep Cleaning", 9 },
                    { 75, 120, "Cleaning office spaces, including desks, floors, and windows.", false, "Office Cleaning", 9 },
                    { 76, 100, "Deep cleaning carpets to remove stains, dirt, and odors.", false, "Carpet Cleaning", 9 },
                    { 77, 80, "Cleaning both interior and exterior windows for clarity and shine.", false, "Window Cleaning", 9 },
                    { 78, 150, "Cleaning a home or apartment when moving in or out.", false, "Move-In/Move-Out Cleaning", 9 },
                    { 79, 120, "Using high-pressure water to clean outdoor surfaces like driveways and patios.", false, "Pressure Washing", 9 },
                    { 80, 180, "Cleaning up debris, dust, and materials left after construction or renovation.", false, "Post-Construction Cleaning", 9 },
                    { 81, 50, "Shopping for groceries and delivering them to your doorstep.", false, "Grocery Shopping", 10 },
                    { 82, 75, "Shopping for gifts based on your preferences and budget.", false, "Gift Shopping", 10 },
                    { 83, 60, "Picking up and delivering packages to your location.", false, "Package Pickup & Delivery", 10 },
                    { 84, 100, "Assisting with shopping for clothes, gifts, or other personal items.", false, "Personal Shopping Assistant", 10 },
                    { 85, 70, "Running errands like picking up dry cleaning or post office trips.", false, "Errand Running", 10 },
                    { 86, 55, "Grocery shopping and delivery without physical interaction.", false, "Contactless Grocery Shopping", 11 },
                    { 87, 95, "Furniture assembly with minimal or no physical contact.", false, "Contactless Furniture Assembly", 11 },
                    { 88, 55, "Delivering packages or groceries without in-person contact.", false, "Contactless Delivery", 11 },
                    { 89, 120, "Cleaning services performed with social distancing and minimal contact.", false, "Contactless Cleaning", 11 },
                    { 90, 100, "Assembling IKEA furniture with ease and efficiency.", false, "IKEA Furniture Assembly", 12 },
                    { 91, 120, "Picking up and delivering IKEA furniture or products to your home.", false, "IKEA Pickup & Delivery", 12 },
                    { 92, 150, "Installing IKEA furniture and home solutions in your space.", false, "IKEA Home Installation", 12 },
                    { 93, 120, "Mounting your TV on the wall for a sleek and modern look.", false, "TV Mounting", 13 },
                    { 94, 50, "Hanging artwork, mirrors, or other pictures on your walls.", false, "Picture Hanging", 13 },
                    { 95, 100, "Installing shelves to maximize storage space in your home.", false, "Shelving Installation", 13 },
                    { 96, 120, "Installing or replacing light fixtures throughout your home.", false, "Light Fixture Installation", 13 },
                    { 97, 80, "Installing curtain rods for your windows.", false, "Curtain Rod Installation", 13 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Address", "AppointmentDate", "AppointmentTime", "Cost", "CustomerProfileId", "PersonName", "ProviderServiceId", "ServiceId", "Status", "UserId", "notes" },
                values: new object[,]
                {
                    { 1, "123 Main St, Springfield, IL", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), null, null, "John Doe", null, 1, "Pending", "user1", "Customer requested a quick repair of the sink." },
                    { 2, "456 Elm St, Springfield, IL", new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 30, 0, 0), null, null, "Jane Smith", null, 2, "Confirmed", "user2", "Routine maintenance of air conditioning system." }
                });

            migrationBuilder.InsertData(
                table: "ProviderServices",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Notes", "ProviderProfileId", "ServiceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2708), "https://example.com/images/lawn_mowing.jpg", "Experienced in lawn mowing with professional equipment.", 1, 1, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2709) },
                    { 2, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2711), "https://example.com/images/house_cleaning.jpg", "Thorough house cleaning services with eco-friendly products.", 2, 3, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2712) }
                });

            migrationBuilder.InsertData(
                table: "AppointmentFeedbacks",
                columns: new[] { "Id", "AppointmentId", "CreatedAt", "CustomerProfileId", "Feedback", "IsApproved", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2755), 1, "Great service! Very satisfied.", false, 5, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2756) },
                    { 2, 2, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2759), 2, "Good job, but could be more thorough.", false, 4, new DateTime(2025, 3, 25, 22, 2, 35, 689, DateTimeKind.Utc).AddTicks(2760) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomerProfile_CustomerProfileId",
                table: "AddressCustomerProfile",
                column: "CustomerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentFeedbacks_AppointmentId",
                table: "AppointmentFeedbacks",
                column: "AppointmentId");

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
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

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
                name: "IX_CustomerProfiles_ProfileId",
                table: "CustomerProfiles",
                column: "ProfileId",
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
                name: "AddressCustomerProfile");

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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "ProviderServices");

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
