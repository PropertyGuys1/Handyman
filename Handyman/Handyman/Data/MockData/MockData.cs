using Handyman.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Handyman.Data.MockData
{
    public static class MockData
    {
        //public static List<IdentityUser> GetUsers()
        //{
        //    return new List<IdentityUser>
        //    {
        //        new IdentityUser
        //        {
        //            Id = "customer1",
        //            UserName = "customer1",
        //            Email = "john.doe@example.com",
        //            NormalizedUserName = "CUSTOMER1",
        //            NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
        //            EmailConfirmed = true,
        //            SecurityStamp = Guid.NewGuid().ToString("D"),
        //            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Password123!")
        //        },
        //        new IdentityUser
        //        {
        //            Id = "customer2",
        //            UserName = "customer2",
        //            Email = "jane.smith@example.com",
        //            NormalizedUserName = "CUSTOMER2",
        //            NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
        //            EmailConfirmed = true,
        //            SecurityStamp = Guid.NewGuid().ToString("D"),
        //            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Password123!")
        //        },
        //        new IdentityUser
        //        {
        //            Id = "provider1",
        //            UserName = "provider1",
        //            Email = "mike.johnson@example.com",
        //            NormalizedUserName = "PROVIDER1",
        //            NormalizedEmail = "MIKE.JOHNSON@EXAMPLE.COM",
        //            EmailConfirmed = true,
        //            SecurityStamp = Guid.NewGuid().ToString("D"),
        //            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Password123!")
        //        },
        //        new IdentityUser
        //        {
        //            Id = "provider2",
        //            UserName = "provider2",
        //            Email = "emily.davis@example.com",
        //            NormalizedUserName = "PROVIDER2",
        //            NormalizedEmail = "EMILY.DAVIS@EXAMPLE.COM",
        //            EmailConfirmed = true,
        //            SecurityStamp = Guid.NewGuid().ToString("D"),
        //            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
        //            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Password123!")
        //        }
        //    };
        //}

        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new Profile
                {
                    Id = 1,
                    UserId = "customer1",
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    Address = "123 Main St, Anytown, USA",
                    Role = "Customer",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Profile
                {
                    Id = 2,
                    UserId = "customer2",
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-3210",
                    Address = "456 Elm St, Othertown, USA",
                    Role = "Customer",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Profile
                {
                    Id = 3,
                    UserId = "provider1",
                    FullName = "Mike Johnson",
                    Email = "mike.johnson@example.com",
                    PhoneNumber = "555-123-4567",
                    Address = "789 Oak St, Sometown, USA",
                    Role = "Provider",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Profile
                {
                    Id = 4,
                    UserId = "provider2",
                    FullName = "Emily Davis",
                    Email = "emily.davis@example.com",
                    PhoneNumber = "555-987-6543",
                    Address = "321 Pine St, Anothertown, USA",
                    Role = "Provider",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
        }

        public static List<CustomerProfile> GetCustomerProfiles()
        {
            return new List<CustomerProfile>
            {
                new CustomerProfile
                {
                    Id = 1,
                    ProfileId = 1,
                    Preferences = "Weekly lawn mowing",
                    AddressId = 1

                },
                new CustomerProfile
                {
                    Id = 2,
                    ProfileId = 2,
                    Preferences = "Monthly house cleaning",
                    AddressId = 2
                }
            };
        }

        public static List<ProviderProfile> GetProviderProfiles()
        {
            return new List<ProviderProfile>
            {
                new ProviderProfile
                {
                    Id = 1,
                    ProfileId = 3,
                    ServicesOffered = "Lawn Mowing, Hedge Trimming",
                    Availability = "Mon-Fri 9am-5pm",
                    Rating = 4.5m
                },
                new ProviderProfile
                {
                    Id = 2,
                    ProfileId = 4,
                    ServicesOffered = "House Cleaning, Carpet Cleaning",
                    Availability = "Sat-Sun 10am-4pm",
                    Rating = 4.8m
                }
            };
        }
        public static List<ServiceType> GetServiceTypes()
        {
            return new List<ServiceType>
            {
                new ServiceType
                {
                    Id = 1,
                    Name = "Lawn Care",
                    Description = "Services related to lawn maintenance and care.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 2,
                    Name = "House Cleaning",
                    Description = "Services related to cleaning and maintaining the house.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 3,
                    Name = "Plumbing",
                    Description = "Services related to plumbing and pipe maintenance.",
                    IsDeleted = false
                }
            };
        }

        public static List<Service> GetServices()
        {
            return new List<Service>
            {
            new Service
            {
                Id = 1,
                Name = "Lawn Mowing",
                ServiceTypeId = 1,
                IsDeleted = false
            },
            new Service
            {
                Id = 2,
                Name = "Hedge Trimming",
                ServiceTypeId = 1,
                IsDeleted = false
            },
            new Service
            {
                Id = 3,
                Name = "House Cleaning",
                ServiceTypeId = 2,
                IsDeleted = false
            },
            new Service
            {
                Id = 4,
                Name = "Carpet Cleaning",
                ServiceTypeId = 2,
                IsDeleted = false
            },
            new Service
            {
                Id = 5,
                Name = "Pipe Repair",
                ServiceTypeId = 3,
                IsDeleted = false
            },
            new Service
            {
                Id = 6,
                Name = "Leak Detection",
                ServiceTypeId = 3,
                IsDeleted = false
            }
        };


        }
        public static List<ProviderService> GetProviderServices()
        {
            return new List<ProviderService>
    {
        new ProviderService
        {
            Id = 1,
            ProviderProfileId = 1,
            ServiceId = 1,
            Notes = "Experienced in lawn mowing with professional equipment.",
            ImageUrl = "https://example.com/images/lawn_mowing.jpg",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new ProviderService
        {
            Id = 2,
            ProviderProfileId = 2,
            ServiceId = 3,
            Notes = "Thorough house cleaning services with eco-friendly products.",
            ImageUrl = "https://example.com/images/house_cleaning.jpg",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };
        }
        public static List<Appointment> GetAppointments()
        {
            return new List<Appointment>
    {
        new Appointment
        {
            Id = 1,
            ProviderServiceId = 1,
            CustomerProfileId = 1,
            AppointmentDate = DateTime.UtcNow.AddDays(3),
            CustomerNote = "Please make sure to trim the edges.",
            IsApproved = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new Appointment
        {
            Id = 2,
            ProviderServiceId = 2,
            CustomerProfileId = 2,
            AppointmentDate = DateTime.UtcNow.AddDays(5),
            CustomerNote = "Focus on the kitchen and living room.",
            IsApproved = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };
        }
        public static List<AppointmentFeedback> GetAppointmentFeedbacks()
        {
            return new List<AppointmentFeedback>
    {
        new AppointmentFeedback
        {
            Id = 1,
            AppointmentId = 1,
            CustomerProfileId = 1,
            Feedback = "Great service! Very satisfied.",
            Rating = 5,
            IsApproved = false, // Initially not approved
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new AppointmentFeedback
        {
            Id = 2,
            AppointmentId = 2,
            CustomerProfileId = 2,
            Feedback = "Good job, but could be more thorough.",
            Rating = 4,
            IsApproved = false, // Initially not approved
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };
        }
        public static List<Address> GetAddresses()
        {
            return new List<Address>
    {
        new Address
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            PostalCode = "12345",
            Country = "USA"
        },
        new Address
        {
            Id = 2,
            Street = "456 Elm St",
            City = "Othertown",
            State = "NY",
            PostalCode = "67890",
            Country = "USA"
        }
    };
        }
        public static List<Payment> GetPayments()
        {
            return new List<Payment>
    {
        new Payment
        {
            Id = 1,
            CustomerProfileId = 1,
            AppointmentId = 1,
            Amount = 50.00m,
            PaymentMethod = "Credit Card",
            PaymentDate = DateTime.UtcNow,
            IsSuccessful = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new Payment
        {
            Id = 2,
            CustomerProfileId = 2,
            AppointmentId = 2,
            Amount = 75.00m,
            PaymentMethod = "PayPal",
            PaymentDate = DateTime.UtcNow,
            IsSuccessful = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };
        }
    }
}
