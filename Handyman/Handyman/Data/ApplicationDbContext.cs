using Handyman.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Handyman.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important for Identity!

            // Ensure Identity tables have proper primary keys
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    UserId = "john_d",
                    DisplayName = "John Doe",
                    Email = "johndoe@example.com",
                    Gender = "Male",
                    BirthOfDate = new DateOnly(1990, 5, 15),
                    IsReceivePromotionalEmails = true,
                    IsDeleted = false
                },
                new UserProfile
                {
                    UserId = "jane_smith911",
                    DisplayName = "Jane Smith",
                    Email = "janesmith@example.com",
                    Gender = "Female",
                    BirthOfDate = new DateOnly(1995, 8, 22),
                    IsReceivePromotionalEmails = false,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    CustomerId = "john_d", // Replace with valid user ID
                    ServiceId = Guid.NewGuid(), // Replace with actual Service ID
                    ServiceDateTime = DateTime.Now.AddDays(2), // 2 days later
                    Status = "Scheduled",
                    Urgent = false,
                    Location = "123 Main Street, City",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    CustomerId = "john_d", // Replace with valid user ID
                    ServiceId = Guid.NewGuid(), // Replace with actual Service ID
                    ServiceDateTime = DateTime.Now.AddDays(5), // 5 days later
                    Status = "Pending",
                    Urgent = true,
                    Location = "456 Elm Street, City",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = Guid.NewGuid(),
                    Name = "Plumbing Repair",
                    Description = "Fixing leaks and installing new plumbing fixtures.",
                    Catagory = "Plumbing", // Keeping your property name as 'Catagory'
                    Cost = 150.00m,
                    IsDeleted = false
                },
                new Service
                {
                    Id = Guid.NewGuid(),
                    Name = "Electrical Wiring",
                    Description = "Installation and repair of home electrical systems.",
                    Catagory = "Electrical",
                    Cost = 200.00m,
                    IsDeleted = false
                },
                new Service
                {
                    Id = Guid.NewGuid(),
                    Name = "Carpentry Work",
                    Description = "Custom furniture, doors, and wooden structures.",
                    Catagory = "Carpentry",
                    Cost = 180.00m,
                    IsDeleted = false
                },
                new Service
                {
                    Id = Guid.NewGuid(),
                    Name = "HVAC Maintenance",
                    Description = "Heating, ventilation, and AC system servicing.",
                    Catagory = "HVAC",
                    Cost = 250.00m,
                    IsDeleted = false
                }
            );
        }
    }
}
