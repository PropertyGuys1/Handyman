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
                    ProfileId = "provider1",
                    ServicesOffered = "Lawn Mowing, Hedge Trimming",
                    Availability = "Mon-Fri 9am-5pm",
                    Rating = 4.5m
                },
                new ProviderProfile
                {
                    Id = 2,
                    ProfileId = "provider2",
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

        public static List<Service> GetServices() => new List<Service>
            {
                // Popular tasks
                new Service
                {
                    Id = 1, Name = "Yardwork", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Lawn care, landscaping, and gardening tasks.", Cost = 50,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 2, Name = "Minor Home Repair", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Basic home repairs like fixing leaks and broken fixtures.", Cost = 75,
                    ImageUrl = "/images/serviceImages/PlumbingServices.jpg"
                },
                new Service
                {
                    Id = 3, Name = "Furniture Assembly", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Assembling furniture from flat-pack kits.", Cost = 100,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },
                new Service
                {
                    Id = 4, Name = "Snow Removal", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Clearing snow from driveways, walkways, and roofs.", Cost = 60,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"
                },
                new Service
                {
                    Id = 5, Name = "TV Mounting", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Mounting your TV on the wall for a clean look.", Cost = 120,
                    ImageUrl = "/images/serviceImages/TVMountingServices.jpg"
                },
                new Service
                {
                    Id = 6, Name = "Help Moving", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Assisting with moving furniture or boxes.", Cost = 80,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 7, Name = "Handyman", ServiceTypeId = 1, IsDeleted = false,
                    Description = "General home repairs and maintenance tasks.", Cost = 90,
                    ImageUrl = "/images/serviceImages/GeneralServices.jpg"
                },
                new Service
                {
                    Id = 8, Name = "Painting", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Interior and exterior painting services.", Cost = 150,
                    ImageUrl = "/images/serviceImages/PaintingServices.jpg"
                },
                new Service
                {
                    Id = 9, Name = "Lighting Installation", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Installing light fixtures and bulbs.", Cost = 100,
                    ImageUrl = "/images/serviceImages/LightingServices.jpg"
                },
                new Service
                {
                    Id = 10, Name = "Hang Pictures", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Hanging artwork or pictures on walls.", Cost = 50,
                    ImageUrl = "/images/serviceImages/PaintingMountingServices.jpg"
                },
                new Service
                {
                    Id = 11, Name = "IKEA Services", ServiceTypeId = 1, IsDeleted = false,
                    Description = "Assembly and delivery of IKEA furniture.", Cost = 100,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },

                // Featured Tasks
                new Service
                {
                    Id = 12, Name = "Delivery", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Deliver packages or goods to your location.", Cost = 60,
                    ImageUrl = "/images/serviceImages/DeliveryServices.jpg"
                },
                new Service
                {
                    Id = 13, Name = "Home Repairs", ServiceTypeId = 2, IsDeleted = false,
                    Description = "General home repair services like plumbing, electrical work, etc.", Cost = 120,
                    ImageUrl = "/images/serviceImages/PlumbingServices.jpg"
                },
                new Service
                {
                    Id = 14, Name = "General Cleaning", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Basic home or office cleaning services.", Cost = 80,
                    ImageUrl = "/images/serviceImages/OrganizeOfficeServices.jpg"
                },
                new Service
                {
                    Id = 15, Name = "Assemble Furniture", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Assembling furniture like desks, chairs, or tables.", Cost = 90,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },
                new Service
                {
                    Id = 16, Name = "Help Moving / Hauling", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Help with moving or hauling large items.", Cost = 100,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 17, Name = "Heavy Lifting", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Lifting and transporting heavy objects.", Cost = 80,
                    ImageUrl = "/images/serviceImages/HeavyLiftingServices.jpg"
                },
                new Service
                {
                    Id = 18, Name = "Personal Assistant", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Personal errands and assistance for daily tasks.", Cost = 100,
                    ImageUrl = "/images/serviceImages/PersonalAssistantServices.jpg"
                },
                new Service
                {
                    Id = 19, Name = "Yard Work", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Outdoor maintenance including lawn mowing and trimming.", Cost = 70,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 20, Name = "Queue in Line", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Waiting in line for tickets, products, or services.", Cost = 40,
                    ImageUrl = "/images/serviceImages/WaitingInQueueServices.jpg"
                },
                new Service
                {
                    Id = 21, Name = "Organize Closet", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Organizing your closet space for a more efficient setup.", Cost = 80,
                    ImageUrl = "/images/serviceImages/OrganizeClosetServices.jpg"
                },
                new Service
                {
                    Id = 22, Name = "Office Administration", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Office tasks like data entry, document management, etc.", Cost = 90,
                    ImageUrl = "/images/serviceImages/OfficeAdminServices.jpg"
                },
                new Service
                {
                    Id = 23, Name = "Organization", ServiceTypeId = 2, IsDeleted = false,
                    Description = "Organizing personal spaces, offices, or garages.", Cost = 75,
                    ImageUrl = "/images/serviceImages/OrganizeOfficeServices.jpg"
                },

                // Handyman Services
                new Service
                {
                    Id = 24, Name = "Home Repairs", ServiceTypeId = 3, IsDeleted = false,
                    Description = "General home repair services like plumbing, electrical work, etc.", Cost = 120,
                    ImageUrl = "/images/serviceImages/CarpentryServices.jpg"
                },
                new Service
                {
                    Id = 25, Name = "Assemble Furniture", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Assembling furniture like desks, chairs, or tables.", Cost = 90,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 26, Name = "TV Mounting", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Mounting your TV on the wall for a clean look.", Cost = 120,
                    ImageUrl = "/images/serviceImages/TVMountingServices.jpg"
                },
                new Service
                {
                    Id = 27, Name = "Heavy Lifting", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Lifting and transporting heavy objects.", Cost = 80,
                    ImageUrl = "/images/serviceImages/HeavyLiftingServices.jpg"
                },
                new Service
                {
                    Id = 28, Name = "Painting", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Interior and exterior painting services.", Cost = 150,
                    ImageUrl = "/images/serviceImages/PaintingServices.jpg"
                },
                new Service
                {
                    Id = 29, Name = "Plumbing", ServiceTypeId = 3, IsDeleted = false,
                    Description = "General plumbing repairs and installations.", Cost = 130,
                    ImageUrl = "/images/serviceImages/PlumbingServices.jpg"
                },
                new Service
                {
                    Id = 30, Name = "Yard Work", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Outdoor maintenance including lawn mowing and trimming.", Cost = 70,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 31, Name = "Hang Pictures", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Hanging artwork or pictures on walls.", Cost = 50,
                    ImageUrl = "/images/serviceImages/PaintingMountainServices.jpg"

                },
                new Service
                {
                    Id = 32, Name = "Shelf Mounting", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Mounting shelves on walls for storage and decoration.", Cost = 100,
                    ImageUrl = "/images/serviceImages/ShelfMountingServices.jpg"
                },
                new Service
                {
                    Id = 33, Name = "Light Installation", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Installing light fixtures and bulbs.", Cost = 100,
                    ImageUrl = "/images/serviceImages/LightingServices.jpg"
                },
                new Service
                {
                    Id = 34, Name = "Electrical Work", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Electrical installations and repairs.", Cost = 150,
                    ImageUrl = "/images/serviceImages/ElectricalServices.jpg"
                },
                new Service
                {
                    Id = 35, Name = "Carpentry", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Custom woodwork and carpentry services.", Cost = 200,
                    ImageUrl = "/images/serviceImages/CarpentryServices.jpg"
                },
                new Service
                {
                    Id = 36, Name = "Baby Proofing", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Child-proofing your home with safety measures.", Cost = 80,
                    ImageUrl = "/images/serviceImages/BabyProofingServices.jpg"
                },
                new Service
                {
                    Id = 37, Name = "Smart Home Installation", ServiceTypeId = 3, IsDeleted = false,
                    Description = "Installation of smart devices like thermostats, cameras, etc.", Cost = 180,
                    ImageUrl = "/images/serviceImages/SmartHomeServices.jpg"
                },

                // Moving Services
                new Service
                {
                    Id = 38, Name = "Help Moving / Hauling", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Help with moving or hauling large items.", Cost = 100,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 39, Name = "One Item Movers", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Moving a single item, like a couch or appliance.", Cost = 75,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 40, Name = "Furniture Movers", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Moving large furniture from one location to another.", Cost = 150,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 41, Name = "Junk Removal", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Removal and disposal of unwanted items or junk.", Cost = 80,
                    ImageUrl = "/images/serviceImages/JunkRemovalServices.jpg"
                },
                new Service
                {
                    Id = 42, Name = "Full Service Movers", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Complete moving service, including packing, loading, and unloading.", Cost = 300,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 43, Name = "Packing and Moving Services", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Packing up your home and moving everything to your new location.", Cost = 250,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 44, Name = "Unpacking Services", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Unpacking boxes and organizing items in your new home.", Cost = 150,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 45, Name = "Heavy Lifting", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Lifting and transporting heavy objects.", Cost = 80,
                    ImageUrl = "/images/serviceImages/HeavyLiftingServices.jpg"
                },
                new Service
                {
                    Id = 46, Name = "Furniture Removal", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Removal of old furniture that needs to be disposed of.", Cost = 90,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 47, Name = "Couch Removal", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Removal of an old couch or sofa.", Cost = 75,
                    ImageUrl = "/images/serviceImages/MovingServices.jpg"
                },
                new Service
                {
                    Id = 48, Name = "Move Furniture Up/Downstairs", ServiceTypeId = 4, IsDeleted = false,
                    Description = "Assisting in moving furniture up or down stairs.", Cost = 100,
                    ImageUrl = "/images/serviceImages/HeavyLiftingServices.jpg"
                },

                // Holiday Help
                new Service
                {
                    Id = 49, Name = "Hang Christmas Lights", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Decorating your home with Christmas lights.", Cost = 120,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"
                },
                new Service
                {
                    Id = 50, Name = "Christmas Tree Delivery", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Delivery of a Christmas tree to your home.", Cost = 80,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"

                },
                new Service
                {
                    Id = 51, Name = "Christmas Decorating", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Decorating your home for the holidays.", Cost = 150,
                    ImageUrl = "/images/serviceImages/ChristmasServices.jpg"
                },
                new Service
                {
                    Id = 52, Name = "Shopping", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Shopping for holiday gifts or groceries.", Cost = 100,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"
                },
                new Service
                {
                    Id = 53, Name = "Holiday Shopping", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Complete shopping for the holidays.", Cost = 150,
                    ImageUrl = "/images/serviceImages/ChristmasServices.jpg"
                },
                new Service
                {
                    Id = 54, Name = "Gifts Wrapping", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Wrapping your holiday gifts.", Cost = 50,
                    ImageUrl = "/images/serviceImages/ChristmasServices.jpg"
                },
                new Service
                {
                    Id = 55, Name = "Grocery Shopping", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Holiday grocery shopping.", Cost = 80,
                    ImageUrl = "/images/serviceImages/ChristmasServices.jpg"
                },
                new Service
                {
                    Id = 56, Name = "Gift Shopping", ServiceTypeId = 5, IsDeleted = false,
                    Description = "Shopping for holiday gifts.", Cost = 100,
                    ImageUrl = "/images/serviceImages/ChristmasServices.jpg"
                },

                // Furniture Assembly
                new Service
                {
                    Id = 57, Name = "Furniture Assembly", ServiceTypeId = 6, IsDeleted = false,
                    Description = "Assembling furniture like desks, chairs, or tables.", Cost = 90,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 58, Name = "IKEA Furniture Assembly", ServiceTypeId = 6, IsDeleted = false,
                    Description = "Assembling IKEA flat-pack furniture.", Cost = 100,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },
                new Service
                {
                    Id = 59, Name = "Assembly of Kids Furniture", ServiceTypeId = 6, IsDeleted = false,
                    Description = "Assembling kids furniture like cribs, dressers, etc.", Cost = 100,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 60, Name = "Office Furniture Assembly", ServiceTypeId = 6, IsDeleted = false,
                    Description = "Assembling office furniture like desks and chairs.", Cost = 120,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 61, Name = "Shed Assembly", ServiceTypeId = 6, IsDeleted = false,
                    Description = "Assembling outdoor sheds or storage units.", Cost = 150,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },

                // Winter Tasks
                new Service
                {
                    Id = 62, Name = "Snow Removal", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Clearing snow from driveways, walkways, and roofs.", Cost = 60,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"
                },
                new Service
                {
                    Id = 63, Name = "Ice Melting", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Applying ice-melting substances to prevent slips and falls.", Cost = 50,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 64, Name = "Winterizing Property", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Preparing your property for winter by sealing windows, pipes, etc.", Cost = 150,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 65, Name = "Gutter Cleaning", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Cleaning leaves and debris from gutters to prevent blockages.", Cost = 100,
                    ImageUrl = "/images/serviceImages/GeneralServices.jpg"
                },
                new Service
                {
                    Id = 66, Name = "Shoveling Driveways", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Shoveling snow off driveways to ensure safe access.", Cost = 70,
                    ImageUrl = "/images/serviceImages/WinterServices.jpg"
                },
                new Service
                {
                    Id = 67, Name = "Winterizing Plumbing", ServiceTypeId = 7, IsDeleted = false,
                    Description = "Protecting pipes from freezing by insulating or draining them.", Cost = 120,
                    ImageUrl = "/images/serviceImages/PlumbingServices.jpg"
                },

                // Yard Work
                new Service
                {
                    Id = 68, Name = "Lawn Care", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Maintaining your lawn with mowing, fertilization, and watering.", Cost = 80,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 69, Name = "Tree Pruning", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Trimming trees and removing dead branches for safety and appearance.", Cost = 120,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 70, Name = "Leaf Raking", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Raking and removing fallen leaves from yards and lawns.", Cost = 60,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 71, Name = "Lawn Mowing", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Mowing your lawn to maintain a neat and healthy yard.", Cost = 50,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 72, Name = "Gardening", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Planting and caring for flowers, shrubs, and vegetable gardens.", Cost = 90,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },
                new Service
                {
                    Id = 73, Name = "Mulching", ServiceTypeId = 8, IsDeleted = false,
                    Description = "Applying mulch to garden beds to retain moisture and suppress weeds.", Cost = 100,
                    ImageUrl = "/images/serviceImages/LawnServices.jpg"
                },

                // Cleaning
                new Service
                {
                    Id = 74, Name = "Deep Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Thorough cleaning of all surfaces, including hard-to-reach areas.", Cost = 150,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 75, Name = "Office Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Cleaning office spaces, including desks, floors, and windows.", Cost = 120,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 76, Name = "Carpet Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Deep cleaning carpets to remove stains, dirt, and odors.", Cost = 100,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 77, Name = "Window Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Cleaning both interior and exterior windows for clarity and shine.", Cost = 80,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 78, Name = "Move-In/Move-Out Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Cleaning a home or apartment when moving in or out.", Cost = 150,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 79, Name = "Pressure Washing", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Using high-pressure water to clean outdoor surfaces like driveways and patios.", Cost = 120,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },
                new Service
                {
                    Id = 80, Name = "Post-Construction Cleaning", ServiceTypeId = 9, IsDeleted = false,
                    Description = "Cleaning up debris, dust, and materials left after construction or renovation.", Cost = 180,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },

                // Shopping & Delivery
                new Service
                {
                    Id = 81, Name = "Grocery Shopping", ServiceTypeId = 10, IsDeleted = false,
                    Description = "Shopping for groceries and delivering them to your doorstep.", Cost = 50,
                    ImageUrl = "/images/serviceImages/PersonalAssistantServices.jpg"
                },
                new Service
                {
                    Id = 82, Name = "Gift Shopping", ServiceTypeId = 10, IsDeleted = false,
                    Description = "Shopping for gifts based on your preferences and budget.", Cost = 75,
                    ImageUrl = "/images/serviceImages/PersonalAssistantServices.jpg"
                },
                new Service
                {
                    Id = 83, Name = "Package Pickup & Delivery", ServiceTypeId = 10, IsDeleted = false,
                    Description = "Picking up and delivering packages to your location.", Cost = 60,
                    ImageUrl = "/images/serviceImages/DeliveryServices.jpg"
                },
                new Service
                {
                    Id = 84, Name = "Personal Shopping Assistant", ServiceTypeId = 10, IsDeleted = false,
                    Description = "Assisting with shopping for clothes, gifts, or other personal items.", Cost = 100,
                    ImageUrl = "/images/serviceImages/PersonalAssistantServices.jpg"
                },
                new Service
                {
                    Id = 85, Name = "Errand Running", ServiceTypeId = 10, IsDeleted = false,
                    Description = "Running errands like picking up dry cleaning or post office trips.", Cost = 70,
                    ImageUrl = "/images/serviceImages/PersonalAssistantServices.jpg"
                },

                // Contactless Tasks
                new Service
                {
                    Id = 86, Name = "Contactless Grocery Shopping", ServiceTypeId = 11, IsDeleted = false,
                    Description = "Grocery shopping and delivery without physical interaction.", Cost = 55,
                    ImageUrl = "/images/serviceImages/DeliveryServices.jpg"
                },
                new Service
                {
                    Id = 87, Name = "Contactless Furniture Assembly", ServiceTypeId = 11, IsDeleted = false,
                    Description = "Furniture assembly with minimal or no physical contact.", Cost = 95,
                    ImageUrl = "/images/serviceImages/AssemblyServices.jpg"
                },
                new Service
                {
                    Id = 88, Name = "Contactless Delivery", ServiceTypeId = 11, IsDeleted = false,
                    Description = "Delivering packages or groceries without in-person contact.", Cost = 55,
                    ImageUrl = "/images/serviceImages/DeliveryServices.jpg"
                },
                new Service
                {
                    Id = 89, Name = "Contactless Cleaning", ServiceTypeId = 11, IsDeleted = false,
                    Description = "Cleaning services performed with social distancing and minimal contact.", Cost = 120,
                    ImageUrl = "/images/serviceImages/CleaningServices.jpg"
                },

                // IKEA Services
                new Service
                {
                    Id = 90, Name = "IKEA Furniture Assembly", ServiceTypeId = 12, IsDeleted = false,
                    Description = "Assembling IKEA furniture with ease and efficiency.", Cost = 100,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },
                new Service
                {
                    Id = 91, Name = "IKEA Pickup & Delivery", ServiceTypeId = 12, IsDeleted = false,
                    Description = "Picking up and delivering IKEA furniture or products to your home.", Cost = 120,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },
                new Service
                {
                    Id = 92, Name = "IKEA Home Installation", ServiceTypeId = 12, IsDeleted = false,
                    Description = "Installing IKEA furniture and home solutions in your space.", Cost = 150,
                    ImageUrl = "/images/serviceImages/IKEAServices.jpg"
                },

                // Mounting & Installation
                new Service
                {
                    Id = 93, Name = "TV Mounting", ServiceTypeId = 13, IsDeleted = false,
                    Description = "Mounting your TV on the wall for a sleek and modern look.", Cost = 120,
                    ImageUrl = "/images/serviceImages/TVMountingServices.jpg"
                },
                new Service
                {
                    Id = 94, Name = "Picture Hanging", ServiceTypeId = 13, IsDeleted = false,
                    Description = "Hanging artwork, mirrors, or other pictures on your walls.", Cost = 50,
                    ImageUrl = "/images/serviceImages/PaintingMountingServices.jpg"
                },
                new Service
                {
                    Id = 95, Name = "Shelving Installation", ServiceTypeId = 13, IsDeleted = false,
                    Description = "Installing shelves to maximize storage space in your home.", Cost = 100,
                    ImageUrl = "/images/serviceImages/ShelfMountingServices.jpg"
                },
                new Service
                {
                    Id = 96, Name = "Light Fixture Installation", ServiceTypeId = 13, IsDeleted = false,
                    Description = "Installing or replacing light fixtures throughout your home.", Cost = 120,
                    ImageUrl = "/images/serviceImages/LightingServices.jpg"
                },
                new Service
                {
                    Id = 97, Name = "Curtain Rod Installation", ServiceTypeId = 13, IsDeleted = false,
                    Description = "Installing curtain rods for your windows.", Cost = 80,
                    ImageUrl = "/images/serviceTypeImages/MountingInstallationServiceType.jpg"
                }


            };

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
                    AppointmentDate = new DateTime(2025, 3, 5), // Example appointment date
                    AppointmentTime = new TimeSpan(10, 0, 0), // Example appointment time: 10:00 AM
                    Status = "Pending", // Example status
                    ServiceId = 1, // Reference to an existing ServiceId
                    UserId = "user1", // User who booked the service (this should exist in your Users table)
                    notes = "Customer requested a quick repair of the sink."
                },
                new Appointment
                {
                    Id = 2,
                    PersonName = "Jane Smith",
                    Address = "456 Elm St, Springfield, IL",
                    AppointmentDate = new DateTime(2025, 3, 6),
                    AppointmentTime = new TimeSpan(14, 30, 0), // 2:30 PM
                    Status = "Confirmed",
                    ServiceId = 2, // Ensure ServiceId 2 exists in the Service table
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

        /*public static List<Address> GetAddresses()
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
        }*/

        /*public static List<Payment> GetPayments()
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
        }*/
    }
}