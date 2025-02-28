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
        public DbSet<Address> Addresses { get; set; }
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

            /*
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
                .HasForeignKey<Payment>(p => p.AppointmentId);*/

            modelBuilder.Entity<AppointmentFeedback>()
                .HasOne(af => af.CustomerProfile)
                .WithMany(cp => cp.AppointmentFeedbacks)
                .HasForeignKey(af => af.CustomerProfileId);

            modelBuilder.Entity<CustomerProfile>()
                .HasMany(cp => cp.Addresses)
                .WithMany();

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

    }
}