using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Handyman.Migrations
{
    /// <inheritdoc />
    public partial class Testing12345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Lawn care, landscaping, and gardening tasks." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 75, "Basic home repairs like fixing leaks and broken fixtures." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assembling furniture from flat-pack kits." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 60, "Clearing snow from driveways, walkways, and roofs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Mounting your TV on the wall for a clean look." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Assisting with moving furniture or boxes." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "General home repairs and maintenance tasks." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Interior and exterior painting services." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Installing light fixtures and bulbs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Hanging artwork or pictures on walls." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assembly and delivery of IKEA furniture." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 60, "Deliver packages or goods to your location." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "General home repair services like plumbing, electrical work, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Basic home or office cleaning services." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Assembling furniture like desks, chairs, or tables." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Help with moving or hauling large items." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Lifting and transporting heavy objects." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Personal errands and assistance for daily tasks." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 70, "Outdoor maintenance including lawn mowing and trimming." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 40, "Waiting in line for tickets, products, or services." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Organizing your closet space for a more efficient setup." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Office tasks like data entry, document management, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 75, "Organizing personal spaces, offices, or garages." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "General home repair services like plumbing, electrical work, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Assembling furniture like desks, chairs, or tables." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Mounting your TV on the wall for a clean look." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Lifting and transporting heavy objects." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Interior and exterior painting services." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 130, "General plumbing repairs and installations." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 70, "Outdoor maintenance including lawn mowing and trimming." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Hanging artwork or pictures on walls." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Mounting shelves on walls for storage and decoration." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Installing light fixtures and bulbs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Electrical installations and repairs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 200, "Custom woodwork and carpentry services." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Child-proofing your home with safety measures." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 180, "Installation of smart devices like thermostats, cameras, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Help with moving or hauling large items." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 75, "Moving a single item, like a couch or appliance." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Moving large furniture from one location to another." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Removal and disposal of unwanted items or junk." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 300, "Complete moving service, including packing, loading, and unloading." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 250, "Packing up your home and moving everything to your new location." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Unpacking boxes and organizing items in your new home." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Lifting and transporting heavy objects." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Removal of old furniture that needs to be disposed of." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 75, "Removal of an old couch or sofa." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assisting in moving furniture up or down stairs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Decorating your home with Christmas lights." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Delivery of a Christmas tree to your home." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Decorating your home for the holidays." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Shopping for holiday gifts or groceries." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Complete shopping for the holidays." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Wrapping your holiday gifts." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Holiday grocery shopping." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Shopping for holiday gifts." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Assembling furniture like desks, chairs, or tables." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assembling IKEA flat-pack furniture." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assembling kids furniture like cribs, dressers, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Assembling office furniture like desks and chairs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Assembling outdoor sheds or storage units." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 60, "Clearing snow from driveways, walkways, and roofs." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Applying ice-melting substances to prevent slips and falls." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Preparing your property for winter by sealing windows, pipes, etc." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Cleaning leaves and debris from gutters to prevent blockages." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 70, "Shoveling snow off driveways to ensure safe access." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Protecting pipes from freezing by insulating or draining them." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Maintaining your lawn with mowing, fertilization, and watering." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Trimming trees and removing dead branches for safety and appearance." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 60, "Raking and removing fallen leaves from yards and lawns." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Mowing your lawn to maintain a neat and healthy yard." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 90, "Planting and caring for flowers, shrubs, and vegetable gardens." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Applying mulch to garden beds to retain moisture and suppress weeds." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Thorough cleaning of all surfaces, including hard-to-reach areas." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Cleaning office spaces, including desks, floors, and windows." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Deep cleaning carpets to remove stains, dirt, and odors." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Cleaning both interior and exterior windows for clarity and shine." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Cleaning a home or apartment when moving in or out." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Using high-pressure water to clean outdoor surfaces like driveways and patios." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 180, "Cleaning up debris, dust, and materials left after construction or renovation." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Shopping for groceries and delivering them to your doorstep." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 75, "Shopping for gifts based on your preferences and budget." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 60, "Picking up and delivering packages to your location." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assisting with shopping for clothes, gifts, or other personal items." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 70, "Running errands like picking up dry cleaning or post office trips." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 55, "Grocery shopping and delivery without physical interaction." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 95, "Furniture assembly with minimal or no physical contact." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 55, "Delivering packages or groceries without in-person contact." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Cleaning services performed with social distancing and minimal contact." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Assembling IKEA furniture with ease and efficiency." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Picking up and delivering IKEA furniture or products to your home." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 150, "Installing IKEA furniture and home solutions in your space." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Mounting your TV on the wall for a sleek and modern look." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 50, "Hanging artwork, mirrors, or other pictures on your walls." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 100, "Installing shelves to maximize storage space in your home." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 120, "Installing or replacing light fixtures throughout your home." });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Cost", "Description" },
                values: new object[] { 80, "Installing curtain rods for your windows." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6171), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6172) });

            migrationBuilder.UpdateData(
                table: "AppointmentFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6175), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6176) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6227), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6226), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PaymentDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6231), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6230), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5529), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5541), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5541) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5544), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5546), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5989), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5992), new DateTime(2025, 3, 3, 23, 59, 19, 118, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Cost", "Description" },
                values: new object[] { null, null });
        }
    }
}
