using Handyman.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Handyman.Data.MockData
{
    public static class MockData
    {

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
                    Password = "jhon123",
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
                    Password = "jane123",
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
                    Password = "mike123",
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
                    Password = "emily123",
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
                    Name = "Popular Tasks",
                    Description = "Most commonly requested services.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 2,
                    Name = "Featured Tasks",
                    Description = "Handpicked services for special needs.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 3,
                    Name = "Handyman Services",
                    Description = "General handyman and repair services.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 4,
                    Name = "Moving Services",
                    Description = "Services for helping with moving and hauling.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 5,
                    Name = "Holiday Help",
                    Description = "Services related to holiday preparations.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 6,
                    Name = "Furniture Assembly",
                    Description = "Services for assembling furniture.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 7,
                    Name = "Winter Tasks",
                    Description = "Services for winter-related tasks.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 8,
                    Name = "Yard Work",
                    Description = "Services for lawn and garden care.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 9,
                    Name = "Cleaning",
                    Description = "Cleaning and disinfecting services.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 10,
                    Name = "Shopping & Delivery",
                    Description = "Services related to shopping and delivery.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 11,
                    Name = "Contactless Tasks",
                    Description = "Services that can be performed contactlessly.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 12,
                    Name = "IKEA Services",
                    Description = "Services related to IKEA products.",
                    IsDeleted = false
                },
                new ServiceType
                {
                    Id = 13,
                    Name = "Mounting & Installation",
                    Description = "Mounting and installation tasks.",
                    IsDeleted = false
                }
            };
        }

        public static List<Service> GetServices()
        {
            return new List<Service>
            {
                //Popular tasks
                new Service { Id = 1, Name = "Yardwork", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 2, Name = "Minor Home Repair", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 3, Name = "Furniture Assembly", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 4, Name = "Snow Removal", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 5, Name = "TV Mounting", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 6, Name = "Help Moving", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 7, Name = "Handyman", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 8, Name = "Painting", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 9, Name = "Lighting Installation", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 10, Name = "Hang Pictures", ServiceTypeId = 1, IsDeleted = false },
                new Service { Id = 11, Name = "IKEA Services", ServiceTypeId = 1, IsDeleted = false },

                // Featured Tasks
                new Service { Id = 12, Name = "Delivery", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 13, Name = "Home Repairs", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 14, Name = "General Cleaning", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 15, Name = "Assemble Furniture", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 16, Name = "Help Moving / Hauling", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 17, Name = "Heavy Lifting", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 18, Name = "Personal Assistant", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 19, Name = "Yard Work", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 20, Name = "Queue in Line", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 21, Name = "Organize Closet", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 22, Name = "Office Administration", ServiceTypeId = 2, IsDeleted = false },
                new Service { Id = 23, Name = "Organization", ServiceTypeId = 2, IsDeleted = false },

                // Handyman Services
                new Service { Id = 24, Name = "Home Repairs", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 25, Name = "Assemble Furniture", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 26, Name = "TV Mounting", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 27, Name = "Heavy Lifting", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 28, Name = "Painting", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 29, Name = "Plumbing", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 30, Name = "Yard Work", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 31, Name = "Hang Pictures", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 32, Name = "Shelf Mounting", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 33, Name = "Light Installation", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 34, Name = "Electrical Work", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 35, Name = "Carpentry", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 36, Name = "Baby Proofing", ServiceTypeId = 3, IsDeleted = false },
                new Service { Id = 37, Name = "Smart Home Installation", ServiceTypeId = 3, IsDeleted = false },

                // Moving Services
                new Service { Id = 38, Name = "Help Moving / Hauling", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 39, Name = "One Item Movers", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 40, Name = "Furniture Movers", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 41, Name = "Junk Removal", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 42, Name = "Full Service Movers", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 43, Name = "Packing and Moving Services", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 44, Name = "Unpacking Services", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 45, Name = "Heavy Lifting", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 46, Name = "Furniture Removal", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 47, Name = "Couch Removal", ServiceTypeId = 4, IsDeleted = false },
                new Service { Id = 48, Name = "Move Furniture Up/Downstairs", ServiceTypeId = 4, IsDeleted = false },

                // Holiday Help
                new Service { Id = 49, Name = "Hang Christmas Lights", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 50, Name = "Christmas Tree Delivery", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 51, Name = "Christmas Decorating", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 52, Name = "Shopping", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 53, Name = "Holiday Shopping", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 54, Name = "Gifts Wrapping", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 55, Name = "Grocery Shopping", ServiceTypeId = 5, IsDeleted = false },
                new Service { Id = 56, Name = "Gift Shopping", ServiceTypeId = 5, IsDeleted = false },

                // Furniture Assembly
                new Service { Id = 57, Name = "Furniture Assembly", ServiceTypeId = 6, IsDeleted = false },
                new Service { Id = 58, Name = "IKEA Furniture Assembly", ServiceTypeId = 6, IsDeleted = false },
                new Service { Id = 59, Name = "Assembly of Kids Furniture", ServiceTypeId = 6, IsDeleted = false },
                new Service { Id = 60, Name = "Office Furniture Assembly", ServiceTypeId = 6, IsDeleted = false },
                new Service { Id = 61, Name = "Shed Assembly", ServiceTypeId = 6, IsDeleted = false },

                // Winter Tasks
                new Service { Id = 62, Name = "Snow Removal", ServiceTypeId = 7, IsDeleted = false },
                new Service { Id = 63, Name = "Ice Melting", ServiceTypeId = 7, IsDeleted = false },
                new Service { Id = 64, Name = "Winterizing Property", ServiceTypeId = 7, IsDeleted = false },
                new Service { Id = 65, Name = "Gutter Cleaning", ServiceTypeId = 7, IsDeleted = false },
                new Service { Id = 66, Name = "Shoveling Driveways", ServiceTypeId = 7, IsDeleted = false },
                new Service { Id = 67, Name = "Winterizing Plumbing", ServiceTypeId = 7, IsDeleted = false },

                // Yard Work
                new Service { Id = 68, Name = "Lawn Care", ServiceTypeId = 8, IsDeleted = false },
                new Service { Id = 69, Name = "Tree Pruning", ServiceTypeId = 8, IsDeleted = false },
                new Service { Id = 70, Name = "Leaf Raking", ServiceTypeId = 8, IsDeleted = false },
                new Service { Id = 71, Name = "Lawn Mowing", ServiceTypeId = 8, IsDeleted = false },
                new Service { Id = 72, Name = "Gardening", ServiceTypeId = 8, IsDeleted = false },
                new Service { Id = 73, Name = "Mulching", ServiceTypeId = 8, IsDeleted = false },

                // Cleaning
                new Service { Id = 74, Name = "Deep Cleaning", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 75, Name = "Office Cleaning", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 76, Name = "Carpet Cleaning", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 77, Name = "Window Cleaning", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 78, Name = "Move-In/Move-Out Cleaning", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 79, Name = "Pressure Washing", ServiceTypeId = 9, IsDeleted = false },
                new Service { Id = 80, Name = "Post-Construction Cleaning", ServiceTypeId = 9, IsDeleted = false },

                // Shopping & Delivery
                new Service { Id = 81, Name = "Grocery Shopping", ServiceTypeId = 10, IsDeleted = false },
                new Service { Id = 82, Name = "Gift Shopping", ServiceTypeId = 10, IsDeleted = false },
                new Service { Id = 83, Name = "Package Pickup & Delivery", ServiceTypeId = 10, IsDeleted = false },
                new Service { Id = 84, Name = "Personal Shopping Assistant", ServiceTypeId = 10, IsDeleted = false },
                new Service { Id = 85, Name = "Errand Running", ServiceTypeId = 10, IsDeleted = false },

                // Contactless Tasks
                new Service { Id = 86, Name = "Contactless Grocery Shopping", ServiceTypeId = 11, IsDeleted = false },
                new Service { Id = 87, Name = "Contactless Furniture Assembly", ServiceTypeId = 11, IsDeleted = false },
                new Service { Id = 88, Name = "Contactless Delivery", ServiceTypeId = 11, IsDeleted = false },
                new Service { Id = 89, Name = "Contactless Cleaning", ServiceTypeId = 11, IsDeleted = false },

                // IKEA Services
                new Service { Id = 90, Name = "IKEA Furniture Assembly", ServiceTypeId = 12, IsDeleted = false },
                new Service { Id = 91, Name = "IKEA Pickup & Delivery", ServiceTypeId = 12, IsDeleted = false },
                new Service { Id = 92, Name = "IKEA Home Installation", ServiceTypeId = 12, IsDeleted = false },

                // Mounting & Installation
                new Service { Id = 93, Name = "TV Mounting", ServiceTypeId = 13, IsDeleted = false },
                new Service { Id = 94, Name = "Picture Hanging", ServiceTypeId = 13, IsDeleted = false },
                new Service { Id = 95, Name = "Shelving Installation", ServiceTypeId = 13, IsDeleted = false },
                new Service { Id = 96, Name = "Light Fixture Installation", ServiceTypeId = 13, IsDeleted = false },
                new Service { Id = 97, Name = "Curtain Rod Installation", ServiceTypeId = 13, IsDeleted = false }

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
                    PersonName = "John Doe",
                    Address = "123 Main St, Springfield, IL",
                    AppointmentDate = new DateTime(2025, 3, 5),  // Example appointment date
                    AppointmentTime = new TimeSpan(10, 0, 0),   // Example appointment time: 10:00 AM
                    Status = "Pending",                         // Example status
                    ServiceId = 1,                              // Reference to an existing ServiceId
                    UserId = "user1",                           // User who booked the service (this should exist in your Users table)
                    notes = "Customer requested a quick repair of the sink."
                },
                new Appointment
                {
                    Id = 2,
                    PersonName = "Jane Smith",
                    Address = "456 Elm St, Springfield, IL",
                    AppointmentDate = new DateTime(2025, 3, 6),
                    AppointmentTime = new TimeSpan(14, 30, 0),  // 2:30 PM
                    Status = "Confirmed",
                    ServiceId = 2,  // Ensure ServiceId 2 exists in the Service table
                    UserId = "user2",
                    notes = "Routine maintenance of air conditioning system."
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
            userId = "dfasdfas",
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            PostalCode = "12345",
            Country = "USA"
        },
        new Address
        {
            Id = 2,
            userId = "dfasdfas",
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