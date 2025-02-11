using Handyman.Data.Entities;
using Handyman.Data.MockData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Handyman.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<ProviderProfile> ProviderProfiles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentFeedback> AppointmentFeedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure foreign key relationship
            modelBuilder.Entity<Profile>()
               .HasOne(p => p.CustomerProfile)
               .WithOne(cp => cp.Profile)
               .HasForeignKey<CustomerProfile>(cp => cp.ProfileId);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.ProviderProfile)
                .WithOne(pp => pp.Profile)
                .HasForeignKey<ProviderProfile>(pp => pp.ProfileId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.ServiceType)
                .WithMany(st => st.Services)
                .HasForeignKey(s => s.ServiceTypeId);

            modelBuilder.Entity<ProviderService>()
                .HasOne(ps => ps.ProviderProfile)
                .WithMany(pp => pp.ProviderServices)
                .HasForeignKey(ps => ps.ProviderProfileId);

            modelBuilder.Entity<ProviderService>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.ProviderServices)
                .HasForeignKey(ps => ps.ServiceId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.ProviderService)
                .WithMany(ps => ps.Appointments)
                .HasForeignKey(a => a.ProviderServiceId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.CustomerProfile)
                .WithMany(cp => cp.Appointments)
                .HasForeignKey(a => a.CustomerProfileId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.AppointmentFeedback)
                .WithOne(af => af.Appointment)
                .HasForeignKey<AppointmentFeedback>(af => af.AppointmentId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Payment)
                .WithOne(p => p.Appointment)
                .HasForeignKey<Payment>(p => p.AppointmentId);

            modelBuilder.Entity<AppointmentFeedback>()
                .HasOne(af => af.CustomerProfile)
                .WithMany(cp => cp.AppointmentFeedbacks)
                .HasForeignKey(af => af.CustomerProfileId);

            modelBuilder.Entity<CustomerProfile>()
                .HasOne(cp => cp.Address)
                .WithMany()
                .HasForeignKey(cp => cp.AddressId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.CustomerProfile)
                .WithMany(cp => cp.Payments)
                .HasForeignKey(p => p.CustomerProfileId);




            //seed mock data
            //modelBuilder.Entity<IdentityUser>().HasData(MockData.MockData.GetUsers());
            modelBuilder.Entity<Profile>().HasData(MockData.MockData.GetProfiles());
            modelBuilder.Entity<CustomerProfile>().HasData(MockData.MockData.GetCustomerProfiles());
            modelBuilder.Entity<ProviderProfile>().HasData(MockData.MockData.GetProviderProfiles());
            modelBuilder.Entity<ServiceType>().HasData(MockData.MockData.GetServiceTypes());
            modelBuilder.Entity<Service>().HasData(MockData.MockData.GetServices());
            modelBuilder.Entity<ProviderService>().HasData(MockData.MockData.GetProviderServices());
            modelBuilder.Entity<Appointment>().HasData(MockData.MockData.GetAppointments());
            modelBuilder.Entity<AppointmentFeedback>().HasData(MockData.MockData.GetAppointmentFeedbacks());
            modelBuilder.Entity<Address>().HasData(MockData.MockData.GetAddresses());
            modelBuilder.Entity<Payment>().HasData(MockData.MockData.GetPayments());
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
