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
                new Service { Id = 1, Name = "Yardwork", ServiceTypeId = 1, Description = "Book a Handyman to bring your yard to the next level! We offer hedge sculpting/trimming, masonry, and botanical waste removal.", IsDeleted = false , Cost = 25},// DONE (The image that is)
                new Service { Id = 2, Name = "Minor Home Repair", ServiceTypeId = 1, Description = "From power outlet replacement to drywall repair, book a Handyman for easy repair!", IsDeleted = false , Cost = 25},// DONE
                new Service { Id = 3, Name = "Furniture Assembly", ServiceTypeId = 1, Description = "Stubborn and stressful furnature can be a thing of the past with our certified Handymen. Book today and enjoy your new furnature sooner!", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 4, Name = "Snow Removal", ServiceTypeId = 1, Description = "Book one-time or recurring snow removal services. No extra charge for cancellations 12 hours in advance.", IsDeleted = false , Cost = 25},// DONE
                new Service { Id = 5, Name = "TV Mounting", ServiceTypeId = 1, Description = "A certified & insured Handyman will professionally install any TV to any surface! Additional fees may apply for custom fitted bracket mounts.", IsDeleted = false , Cost = 30},// DONE
                new Service { Id = 6, Name = "Help Moving", ServiceTypeId = 1, Description = "Skip the backpain of moving with a team of Handymen! The perfect solution for any moving day!", IsDeleted = false , Cost = 100},// DONE
                new Service { Id = 7, Name = "Handyman", ServiceTypeId = 1, Description = "Hire-A-Handyman. A Jack-of-all-Trades, certified and insured by Handyman™", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 8, Name = "Painting", ServiceTypeId = 1, Description = "Book a helping hand to help you paint on any surface from interior walls to canvas.", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 9, Name = "Lighting Installation", ServiceTypeId = 1, Description = "Light up your life with a professionally installed chandelier! Or act fast and your 4th light install is free!", IsDeleted = false , Cost = 50},// DONE
                new Service { Id = 10, Name = "Hang Pictures", ServiceTypeId = 1, Description = "Never have a precious picture fall or be damaged again with a Handyman™ professional installation.", IsDeleted = false , Cost = 25},
                new Service { Id = 11, Name = "IKEA Services", ServiceTypeId = 1, Description = "Sturdy furnature meets a strong arm. Officially certified by IKEA™", IsDeleted = false , Cost = 60},// DONE

                // Featured Tasks
                new Service { Id = 12, Name = "Delivery", ServiceTypeId = 2, Description = "Take advantage of Handyman's delivery services for both food or materials.", IsDeleted = false , Cost = 20},// DONE
                new Service { Id = 13, Name = "Home Repairs", ServiceTypeId = 2, Description = "From power outlet replacement to drywall repair, book a Handyman for easy repair!", IsDeleted = false , Cost = 50},// DONE
                new Service { Id = 14, Name = "General Cleaning", ServiceTypeId = 2, Description = "Simply point and watch the mess disappear!", IsDeleted = false , Cost = 50},// DONE
                new Service { Id = 15, Name = "Assemble Furniture", ServiceTypeId = 2, Description = "Stubborn and stressful furnature can be a thing of the past with our certified Handymen. Book today and enjoy your new furnature sooner!", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 16, Name = "Help Moving / Hauling", ServiceTypeId = 2, Description = "Skip the backpain of moving with a team of Handymen! The perfect solution for any moving day!", IsDeleted = false , Cost = 100},// DONE
                new Service { Id = 17, Name = "Heavy Lifting", ServiceTypeId = 2, Description = "Heavy objects may cause injury, but Handyman™ is here to stop that. Book a Handyman; health is wealth!", IsDeleted = false , Cost = 40},// DONE
                new Service { Id = 18, Name = "Personal Assistant", ServiceTypeId = 2, Description = "Perfect for those days you with you could split yourself in two. Book the best assistant this side of the tide today!", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 19, Name = "YardWork", ServiceTypeId = 2, Description = "Book a Handyman to bring your yard to the next level! We offer hedge sculpting/trimming, masonry, and botanical waste removal.", IsDeleted = false , Cost = 25},// DONE
                new Service { Id = 20, Name = "Queue in Line", ServiceTypeId = 2, Description = "Skip the worst kind of waiting with Handyman™ today!", IsDeleted = false , Cost = 20},// DONE
                new Service { Id = 21, Name = "Organize Closet", ServiceTypeId = 2, Description = "Our organization expert can turn tornado wreckage into function AND form. Book today and watch as your life becomes clutter free.", IsDeleted = false , Cost = 20},// DONE
                new Service { Id = 22, Name = "Office Administration", ServiceTypeId = 2, Description = "Hire a contractor to handle office administration duties. Permanent and one-time solutions available.", IsDeleted = false , Cost = 75},// DONE
                new Service { Id = 23, Name = "Organization", ServiceTypeId = 2, Description = "Our team of organizational specialists can turn any mess into a functional workplace, playspace, or otherwise. Book a free consultation today!", IsDeleted = false , Cost = 55},// DONE

                // Handyman Services
                new Service { Id = 24, Name = "Home Repairs", ServiceTypeId = 3, Description = "From power outlet replacement to drywall repair, book a Handyman for easy repair!", IsDeleted = false , Cost = 50},// DONE
                new Service { Id = 25, Name = "Assemble Furniture", ServiceTypeId = 3, Description = "Stubborn and stressful furnature can be a thing of the past with our certified Handymen. Book today and enjoy your new furnature sooner!", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 26, Name = "TV Mounting", ServiceTypeId = 3, Description = "A certified & insured Handyman will professionally install any TV to any surface! Additional fees may apply for custom fitted bracket mounts.", IsDeleted = false , Cost = 25},// DONE
                new Service { Id = 27, Name = "Heavy Lifting", ServiceTypeId = 3, Description = "Heavy objects may cause injury, but Handyman™ is here to stop that. Book a Handyman™; health is wealth!", IsDeleted = false , Cost = 40},// DONE
                new Service { Id = 28, Name = "Painting", ServiceTypeId = 3, Description = "Book a helping hand to help you paint on any surface from interior walls to canvas.", IsDeleted = false , Cost = 60},// DONE
                new Service { Id = 29, Name = "Plumbing", ServiceTypeId = 3, Description = "Time to update your bathroom or unclog a stubborn sink? A licenced Handyman™ can.", IsDeleted = false , Cost = 55},// DONE
                new Service { Id = 30, Name = "YardWork", ServiceTypeId = 3, Description = "Book a Handyman to bring your yard to the next level! We offer hedge sculpting/trimming, masonry, and botanical waste removal.", IsDeleted = false , Cost = 25},// DONE
                new Service { Id = 31, Name = "Hang Pictures", ServiceTypeId = 3, Description = "Never have a precious picture fall or be damaged again with a Handyman™ professional installation.", IsDeleted = false , Cost = 20},// DONE
                new Service { Id = 32, Name = "Shelf Mounting", ServiceTypeId = 3, Description = "Have a professional Handyman™ install shelving of your choosing. Satisfaction guaranteed.", IsDeleted = false , Cost = 20},// DONE
                new Service { Id = 33, Name = "Light Installation", ServiceTypeId = 3, Description = "Brighten up your home with expert light fixture installations from our skilled Handymen!", IsDeleted = false , Cost = 40},// DONE
                new Service { Id = 34, Name = "Electrical Work", ServiceTypeId = 3, Description = "Need a light fixture installed or an outlet repaired? Our certified Handymen have you covered!", IsDeleted = false , Cost = 65},// DONE
                new Service { Id = 35, Name = "Carpentry", ServiceTypeId = 3, Description = "From custom woodwork to minor repairs, our skilled Handymen bring craftsmanship to your home!", IsDeleted = false , Cost = 35},// DONE
                new Service { Id = 36, Name = "Baby Proofing", ServiceTypeId = 3, Description = "Keep your little ones safe with our expert baby-proofing services including gate installations, outlet covers, corner guards, door fasteners, and more!", IsDeleted = false , Cost = 35},// DONE
                new Service { Id = 37, Name = "Smart Home Installation", ServiceTypeId = 3, Description = "Handyman™ offeres professional installation of smart home devices & appliances. One year limited warrantee with Handyman™ included!", IsDeleted = false , Cost = 45},// DONE

                // Moving Services
                new Service { Id = 38, Name = "Help Moving/Hauling", ServiceTypeId = 4, Description = "Skip the backpain of moving with a team of Handymen! The perfect solution for any moving day!", IsDeleted = false , Cost = 100},// DONE
                new Service { Id = 39, Name = "One Item Movers", ServiceTypeId = 4, Description = "Specialized service for large items ranging from home appliences to M & G-class vehicles.", IsDeleted = false , Cost = 65},
                new Service { Id = 40, Name = "Furniture Movers", ServiceTypeId = 4, Description = "Avoid exhaustion, hassle, and a cricked neck this moving season! From moving to arranging, a licenced Handyman can handle and furnature, guaranteed.", IsDeleted = false , Cost = 50},
                new Service { Id = 41, Name = "Junk Removal", ServiceTypeId = 4, Description = "Junk removal at an unbeatable price! Handyman™ is committed to proper disposal and will confirm all items to be discarded with the owner and recycle appropriately.", IsDeleted = false , Cost = 35},
                new Service { Id = 42, Name = "Full Service Movers", ServiceTypeId = 4, Description = "A team of professional Handymen will handle everything from A-Z. Satisfaction guaranteed!", IsDeleted = false , Cost = 120},
                new Service { Id = 43, Name = "Packing and Moving Services", ServiceTypeId = 4, Description = "The most laborious part of moving is packing. Say no more with our premium moving service! Satisfaction guaranteed!", IsDeleted = false , Cost = 175},
                new Service { Id = 44, Name = "Unpacking Services", ServiceTypeId = 4, Description = "Book a team of professional Handymen to assist you in making your new house a home. Ask about other unpacking services!", IsDeleted = false , Cost = 65},
                new Service { Id = 45, Name = "Heavy Lifting", ServiceTypeId = 4, Description = "Heavy objects may cause injury, but Handyman™ is here to stop that. Book a Handyman; health is wealth!", IsDeleted = false , Cost = 40},
                new Service { Id = 46, Name = "Furniture Removal", ServiceTypeId = 4, Description = "Say goodbye to any awkward, heavy, or otherwise, unwanted furnature! All waste is appropriately recycled", IsDeleted = false , Cost = 60},
                new Service { Id = 47, Name = "Appliance Removal", ServiceTypeId = 4, Description = "A team of licenced Handymen can remove old or unwanted home appliances. From microwaves to waterheaters. Satisfaction guaranteed!", IsDeleted = false , Cost = 85},
                new Service { Id = 48, Name = "Move Furniture Up/Downstairs", ServiceTypeId = 4, Description = "Leave the danger of moving heavy furnature on stairs to our insured and professional Handymen!", IsDeleted = false , Cost = 35},

                // Holiday Help
                new Service { Id = 49, Name = "Hang Christmas Lights", ServiceTypeId = 5, IsDeleted = false, Description = "Decorating your home with Christmas lights.", Cost = 100 },
                new Service { Id = 50, Name = "Christmas Tree Delivery", ServiceTypeId = 5, IsDeleted = false, Description = "Delivery of a Christmas tree to your home.", Cost = 80 },
                new Service { Id = 51, Name = "Christmas Decorating", ServiceTypeId = 5, IsDeleted = false, Description = "Decorating your home for the holidays.", Cost = 150 },
                new Service { Id = 52, Name = "Shopping", ServiceTypeId = 5, IsDeleted = false, Description = "Shopping for holiday gifts or groceries.", Cost = 100 },
                new Service { Id = 53, Name = "Holiday Shopping", ServiceTypeId = 5, IsDeleted = false, Description = "Complete shopping for the holidays.", Cost = 150 },
                new Service { Id = 54, Name = "Gifts Wrapping", ServiceTypeId = 5, IsDeleted = false, Description = "Wrapping your holiday gifts.", Cost = 50 },
                new Service { Id = 55, Name = "Grocery Shopping", ServiceTypeId = 5, IsDeleted = false, Description = "Holiday grocery shopping.", Cost = 80 },
                new Service { Id = 56, Name = "Gift Shopping", ServiceTypeId = 5, IsDeleted = false, Description = "Shopping for holiday gifts.", Cost = 100 },

                // Furniture Assembly
                new Service { Id = 57, Name = "Furniture Assembly", ServiceTypeId = 6, IsDeleted = false, Description = "Assembling furniture like desks, chairs, or tables.", Cost = 90 },
                new Service { Id = 58, Name = "IKEA Furniture Assembly", ServiceTypeId = 6, IsDeleted = false, Description = "Assembling IKEA flat-pack furniture.", Cost = 100 },
                new Service { Id = 59, Name = "Assembly of Kids Furniture", ServiceTypeId = 6, IsDeleted = false, Description = "Assembling kids furniture like cribs, dressers, etc.", Cost = 100 },
                new Service { Id = 60, Name = "Office Furniture Assembly", ServiceTypeId = 6, IsDeleted = false, Description = "Assembling office furniture like desks and chairs.", Cost = 120 },
                new Service { Id = 61, Name = "Shed Assembly", ServiceTypeId = 6, IsDeleted = false, Description = "Assembling outdoor sheds or storage units.", Cost = 150 },

                // Winter Tasks
                new Service { Id = 62, Name = "Snow Removal", ServiceTypeId = 7, IsDeleted = false, Description = "Clearing snow from driveways, walkways, and roofs.", Cost = 60 },
                new Service { Id = 63, Name = "Ice Melting", ServiceTypeId = 7, IsDeleted = false, Description = "Applying ice-melting substances to prevent slips and falls.", Cost = 50 },
                new Service { Id = 64, Name = "Winterizing Property", ServiceTypeId = 7, IsDeleted = false, Description = "Preparing your property for winter by sealing windows, pipes, etc.", Cost = 150 },
                new Service { Id = 65, Name = "Gutter Cleaning", ServiceTypeId = 7, IsDeleted = false, Description = "Cleaning leaves and debris from gutters to prevent blockages.", Cost = 100 },
                new Service { Id = 66, Name = "Shoveling Driveways", ServiceTypeId = 7, IsDeleted = false, Description = "Shoveling snow off driveways to ensure safe access.", Cost = 70 },
                new Service { Id = 67, Name = "Winterizing Plumbing", ServiceTypeId = 7, IsDeleted = false, Description = "Protecting pipes from freezing by insulating or draining them.", Cost = 120 },

                // Yard Work
                new Service { Id = 68, Name = "Lawn Care", ServiceTypeId = 8, IsDeleted = false, Description = "Maintaining your lawn with mowing, fertilization, and watering.", Cost = 80 },
                new Service { Id = 69, Name = "Tree Pruning", ServiceTypeId = 8, IsDeleted = false, Description = "Trimming trees and removing dead branches for safety and appearance.", Cost = 120 },
                new Service { Id = 70, Name = "Leaf Raking", ServiceTypeId = 8, IsDeleted = false, Description = "Raking and removing fallen leaves from yards and lawns.", Cost = 60 },
                new Service { Id = 71, Name = "Lawn Mowing", ServiceTypeId = 8, IsDeleted = false, Description = "Mowing your lawn to maintain a neat and healthy yard.", Cost = 50 },
                new Service { Id = 72, Name = "Gardening", ServiceTypeId = 8, IsDeleted = false, Description = "Planting and caring for flowers, shrubs, and vegetable gardens.", Cost = 90 },
                new Service { Id = 73, Name = "Mulching", ServiceTypeId = 8, IsDeleted = false, Description = "Applying mulch to garden beds to retain moisture and suppress weeds.", Cost = 100 },

                // Cleaning
                new Service { Id = 74, Name = "Deep Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Thorough cleaning of all surfaces, including hard-to-reach areas.", Cost = 150 },
                new Service { Id = 75, Name = "Office Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Cleaning office spaces, including desks, floors, and windows.", Cost = 120 },
                new Service { Id = 76, Name = "Carpet Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Deep cleaning carpets to remove stains, dirt, and odors.", Cost = 100 },
                new Service { Id = 77, Name = "Window Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Cleaning both interior and exterior windows for clarity and shine.", Cost = 80 },
                new Service { Id = 78, Name = "Move-In/Move-Out Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Cleaning a home or apartment when moving in or out.", Cost = 150 },
                new Service { Id = 79, Name = "Pressure Washing", ServiceTypeId = 9, IsDeleted = false, Description = "Using high-pressure water to clean outdoor surfaces like driveways and patios.", Cost = 120 },
                new Service { Id = 80, Name = "Post-Construction Cleaning", ServiceTypeId = 9, IsDeleted = false, Description = "Cleaning up debris, dust, and materials left after construction or renovation.", Cost = 180 },

                // Shopping & Delivery
                new Service { Id = 81, Name = "Grocery Shopping", ServiceTypeId = 10, IsDeleted = false, Description = "Shopping for groceries and delivering them to your doorstep.", Cost = 50 },
                new Service { Id = 82, Name = "Gift Shopping", ServiceTypeId = 10, IsDeleted = false, Description = "Shopping for gifts based on your preferences and budget.", Cost = 75 },
                new Service { Id = 83, Name = "Package Pickup & Delivery", ServiceTypeId = 10, IsDeleted = false, Description = "Picking up and delivering packages to your location.", Cost = 60 },
                new Service { Id = 84, Name = "Personal Shopping Assistant", ServiceTypeId = 10, IsDeleted = false, Description = "Assisting with shopping for clothes, gifts, or other personal items.", Cost = 100 },
                new Service { Id = 85, Name = "Errand Running", ServiceTypeId = 10, IsDeleted = false, Description = "Running errands like picking up dry cleaning or post office trips.", Cost = 70 },

                // Contactless Tasks
                new Service { Id = 86, Name = "Contactless Grocery Shopping", ServiceTypeId = 11, IsDeleted = false, Description = "Grocery shopping and delivery without physical interaction.", Cost = 55 },
                new Service { Id = 87, Name = "Contactless Furniture Assembly", ServiceTypeId = 11, IsDeleted = false, Description = "Furniture assembly with minimal or no physical contact.", Cost = 95 },
                new Service { Id = 88, Name = "Contactless Delivery", ServiceTypeId = 11, IsDeleted = false, Description = "Delivering packages or groceries without in-person contact.", Cost = 55 },
                new Service { Id = 89, Name = "Contactless Cleaning", ServiceTypeId = 11, IsDeleted = false, Description = "Cleaning services performed with social distancing and minimal contact.", Cost = 120 },

                // IKEA Services
                new Service { Id = 90, Name = "IKEA Furniture Assembly", ServiceTypeId = 12, IsDeleted = false, Description = "Assembling IKEA furniture with ease and efficiency.", Cost = 100 },
                new Service { Id = 91, Name = "IKEA Pickup & Delivery", ServiceTypeId = 12, IsDeleted = false, Description = "Picking up and delivering IKEA furniture or products to your home.", Cost = 120 },
                new Service { Id = 92, Name = "IKEA Home Installation", ServiceTypeId = 12, IsDeleted = false, Description = "Installing IKEA furniture and home solutions in your space.", Cost = 150 },

                // Mounting & Installation
                new Service { Id = 93, Name = "TV Mounting", ServiceTypeId = 13, IsDeleted = false, Description = "Mounting your TV on the wall for a sleek and modern look.", Cost = 120 },
                new Service { Id = 94, Name = "Picture Hanging", ServiceTypeId = 13, IsDeleted = false, Description = "Hanging artwork, mirrors, or other pictures on your walls.", Cost = 50 },
                new Service { Id = 95, Name = "Shelving Installation", ServiceTypeId = 13, IsDeleted = false, Description = "Installing shelves to maximize storage space in your home.", Cost = 100 },
                new Service { Id = 96, Name = "Light Fixture Installation", ServiceTypeId = 13, IsDeleted = false, Description = "Installing or replacing light fixtures throughout your home.", Cost = 120 },
                new Service { Id = 97, Name = "Curtain Rod Installation", ServiceTypeId = 13, IsDeleted = false, Description = "Installing curtain rods for your windows.", Cost = 80 }


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