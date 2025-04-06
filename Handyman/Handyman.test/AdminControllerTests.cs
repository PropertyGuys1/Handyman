using Handyman.Controllers;
using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Handyman.test
{
    public class AdminControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            //making a test database for this test controller
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                //this test database is named by the command below
                .UseInMemoryDatabase(databaseName: "HandymanTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            //make sure its deleted when ran
            _context.Database.EnsureDeleted();
            //after deleting it make sure to create it
            _context.Database.EnsureCreated();

            //this is a prefix for teh controller im making tests for
            _controller = new AdminController(_context);
        }

        [Fact]
        public async Task Index_ReturnsViewWithCustomers_ReturnsOk()
        {
            //Arrange
            //make a new profile for this test
            var newCustomer = new Profile
            {
                UserId = Guid.NewGuid().ToString(), // Ensure a unique ID
                Role = "Customer",
                Email = "test@gmail.com"
            };

            //add this newCustomer to the temp database
            _context.Profiles.Add(newCustomer);
            //save the changes to the temp database
            _context.SaveChanges();

            //Act
            //make sure this controller returns good data
            var result = await _controller.Index();

            //Assert
            //make this type the result
            var viewResult = Assert.IsType<ViewResult>(result);
            //make this model return the intended result
            var model = Assert.IsAssignableFrom<List<Profile>>(viewResult.Model);

            //make sure the test database contains an email with the below data
            Assert.Contains(model, c => c.Email == "test@gmail.com");
        }

        [Fact]
        public async Task Index_ReturnsViewWithInvalidCustomer_ReturnsNotOk()
        {
            //Arrange
            //invalid customer data
            var invalidCustomer = new Profile
            {
                UserId = null,
                Role = "Customer",
                Email = "invalid@gmail.com"
            };

            try
            {
                //add the invalidCustomer to profiles
                _context.Profiles.Add(invalidCustomer);
                //wait for the saves to be synced
                await _context.SaveChangesAsync(); 
            }
            catch (InvalidOperationException ex)
            {
                //make this handle errors incase the test goes wrong
                Assert.Contains("Unable to track an entity of type 'Profile' because alternate key property 'UserId' is null", ex.Message);
                return;
            }
            //looks for this result because we want a not ok result
            Assert.True(false, "Test failed: Invalid customer was added to the database.");
        }

        [Fact]
        public async Task ServiceProviders_ReturnsViewWithInvalidProvider_ReturnsNotOk()
        {
            //make a false provider data
            var invalidProvider = new Profile { UserId = null, Role = "ServiceProvider", Email = "invalid@gmail.com" };
            try
            {
                //make this invalidProvider added to the profiles list
                _context.Profiles.Add(invalidProvider);
                //save the changes we made
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                //make this handle errors
                Assert.Contains("Unable to track an entity of type 'Profile' because alternate key property 'UserId' is null", ex.Message);
                return;
            }
            //make this test be a bad result we want that
            Assert.True(false, "Test failed: Invalid provider was added to the database.");
        }

        [Fact]
        public async Task Appointment_ReturnsViewWithAppointments()
        {
            // Arrange
            var newAppointment = new Appointment { Id = 1, Address = "451 Main Street", PersonName = "John Doe", Status = "Approved", ServiceId = 1, AppointmentDate = DateTime.UtcNow, UserId = "13123123123hoawdhd211" };

            _context.Appointments.Add(newAppointment);
            _context.SaveChanges();

            //Act
            var result = await _controller.Appointment();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Appointment>>(viewResult.Model);
            Assert.Contains(model, a => a.Id == 1);
        }

        [Fact]
        public async Task Appointment_ReturnsEmptyList_WhenNoAppointmentsExist()
        {
            //Arrange
            _context.Appointments.RemoveRange(_context.Appointments);
            _context.SaveChanges();

            //Act
            var result = await _controller.Appointment();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Appointment>>(viewResult.Model);
            Assert.Empty(model);
        }

        [Fact]
        public async Task ServiceType_ReturnsViewWithActiveServiceTypes()
        {
            //Arrange
            var activeServiceType = new ServiceType { Id = 100, Name = "Plumbing", Description = "Fix all of your leaky pipes and toilet issues", IsDeleted = false };
            _context.ServiceTypes.Add(activeServiceType);
            _context.SaveChanges();

            //Act
            var result = await _controller.ServiceType();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ServiceType>>(viewResult.Model);
            Assert.Contains(model, s => s.Id == 1);
        }

        [Fact]
        public async Task ServiceType_ReturnsEmptyList_WhenAllServiceTypesAreDeleted()
        {
            //Arrange
            _context.ServiceTypes.RemoveRange(_context.ServiceTypes);
            _context.SaveChanges();

            
            var deletedServiceTypes = new List<ServiceType>
            {
              new ServiceType { Id = 1, Name = "Plumbing", Description = "Fix all of your leaky pipes and toilet issues", IsDeleted = true },
              new ServiceType { Id = 2, Name = "Electrical", Description = "Fix all of your electrical issues", IsDeleted = true }
            };

            _context.ServiceTypes.AddRange(deletedServiceTypes);
            _context.SaveChanges();

            //Act
            var result = await _controller.ServiceType();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ServiceType>>(viewResult.Model);
            Assert.Empty(model); 
        }

        [Fact]
        public async Task ServiceList_ReturnsViewWithServiceType_WhenIdExists()
        {
            //Arrange
            var serviceType = new ServiceType
            {Id = 101,Name = "Cleaning",Description = "All cleaning purposes",Services = new List<Service>
            {
            new Service { Id = 102, Name = "Deep Cleaning", Description = "Deep cleaning to get the grime out of your house", ServiceTypeId = 3 }
            }
            };

            _context.ServiceTypes.Add(serviceType);
            _context.SaveChanges();

            //Act
            var result = await _controller.ServiceList(3);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ServiceType>(viewResult.Model);
            Assert.Equal(3, model.Id);
        }

        [Fact]
        public async Task ServiceList_ReturnsNotFound_WhenServiceTypeDoesNotExist()
        {
            //Act
            var result = await _controller.ServiceList(999);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Service_ReturnsViewWithActiveServices()
        {
            //Arrange
            var activeService = new Service { Id = 101, Name = "Lawn Mowing", Description = "Mowing your lawn so you can relax", IsDeleted = false };
            _context.Services.Add(activeService);
            _context.SaveChanges();

            //Act
            var result = await _controller.Service();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Service>>(viewResult.Model);
            Assert.Contains(model, s => s.Id == 1);
        }

        [Fact]
        public async Task Service_ReturnsEmptyList_WhenAllServicesAreDeleted()
        {
            //Arrange
            var allServices = _context.Services.ToList();
            foreach (var service in allServices)
            {
                service.IsDeleted = true;
            }
            _context.SaveChanges();

            //Act
            var result = await _controller.Service();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Service>>(viewResult.Model);

            Assert.Empty(model);
        }

        [Fact]
        public async Task AddServiceType_InvalidServiceType_ReturnsViewWithModelError()
        {
            //Arrange
            var validServiceType = new ServiceType { Name = "Plumbing", Description = "Handles all plumbing-related services" };

            // Act
            var result = await _controller.AddServiceType(validServiceType);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceType", redirectResult.ActionName);
        }

        [Fact]
        public async Task EditServiceType_ValidId_ReturnsViewWithServiceType()
        {
            //Arrange
            var serviceType = new ServiceType { Id = 101, Name = "Plumbing", Description = "Handles plumbing issues" };
            _context.ServiceTypes.Add(serviceType);
            _context.SaveChanges();

            // Act
            var result = await _controller.EditServiceType(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ServiceType>(viewResult.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task EditServiceType_InvalidId_ReturnsNotFound()
        {
            //Act
            var result = await _controller.EditServiceType(999);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditServiceType_ValidModel_UpdatesAndRedirects()
        {
            //Arrange
            var serviceType = new ServiceType { Id = 101, Name = "Plumbing", Description = "Handles plumbing issues" };
            _context.ServiceTypes.Add(serviceType);
            _context.SaveChanges();

            //Act
            serviceType.Name = "Updated Plumbing";
            var result = await _controller.EditServiceType(serviceType);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceType", redirectResult.ActionName);
        }

        [Fact]
        public async Task DeleteServiceType_ValidId_DeletesServiceType()
        {
            //Arrange
            var serviceType = new ServiceType { Id = 101, Name = "Plumbing", Description = "Plumbing Services" };
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DeleteServiceType(serviceType.Id);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceType", redirectResult.ActionName); 

            //Assert
            var deletedServiceType = await _context.ServiceTypes.FindAsync(serviceType.Id);
            Assert.True(deletedServiceType.IsDeleted); 
        }

        [Fact]
        public async Task DeleteProfile_ValidId_SoftDeletesProfile()
        {
            //Arrange
            //create static data for this test
            var profile = new Profile { Id = 7, UserId = "12039ajlkdwh9021uj", FullName = "John Doe", Email = "john@example.com", Role = "Customer", Active = true };
            //add this profile data to the temp db
            _context.Profiles.Add(profile);
            //save the changes
            await _context.SaveChangesAsync();

            //Act
            //delete the profile by using the controller
            var result = await _controller.DeleteProfile(profile.Id);

            //Assert
            //redirects it to the right page
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            //wants to go to the index after completing the steps above
            Assert.Equal("Index", redirectResult.ActionName);

            //Assert
            //delete the data form the temp db 
            var deletedProfile = await _context.Profiles.FindAsync(profile.Id);
            //make sure a deleted profile is valid
            Assert.False(deletedProfile.Active);
        }

        [Fact]
        public async Task DeleteProfile_InvalidId_ReturnsView()
        {
            //Act
            //make a bad data on purpose
            var result = await _controller.DeleteProfile(999);

            //Assert
            //return the invalid parameter in the result command
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ActiveProfile_ValidId_ActivatesProfile()
        {
            //Arrange
            //set this data for the test only
            var profile = new Profile { Id = 101, UserId = "09310293jkwadj0984", FullName = "Jane Doe", Email = "jane@example.com", Role = "Provider", Active = false };
            //add profile to this
            _context.Profiles.Add(profile);
            //await the changes to take place
            await _context.SaveChangesAsync();

            //Act
            //save this as a profile by Id
            var result = await _controller.ActiveProfile(profile.Id);

            //Assert
            //what is the assert type
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            
            Assert.Equal("ServiceProviders", redirectResult.ActionName);

            //Assert
            //activated profile that we made for this test above is looked for in the testDb
            var activatedProfile = await _context.Profiles.FindAsync(profile.Id);
            //this test looks for the data above and approves it if it can find it
            Assert.True(activatedProfile.Active);
        }

        [Fact]
        public async Task ActiveProfile_InvalidId_ReturnsView()
        {
            //Act
            //get this invalid id to return a invalid test
            var result = await _controller.ActiveProfile(999);

            //Assert
            //return this expected type 
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DeleteService_ValidId_SoftDeletesService()
        {
            //Arrange
            //add a service information into a temp db just for this
            var service = new Service { Id = 101, Name = "Plumbing Service", ServiceTypeId = 1, Description = "A description", Cost = 100, IsDeleted = false };
            //add this service for validating this test
            _context.Services.Add(service);
            //awaits the chnages to be saved in this test area
            await _context.SaveChangesAsync();

            //Act
            //controller works as intented and dleeted the test service id
            var result = await _controller.DeleteService(service.Id);

            //Assert
            //get the result of this action
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            //redirect to this page
            Assert.Equal("ServiceList", redirectResult.ActionName);

            //Assert
            //try and find the deleted service in the id and if you can't it works
            var deletedService = await _context.Services.FindAsync(service.Id);
            //is the deleted service deleted?
            Assert.True(deletedService.IsDeleted);
        }

        [Fact]
        public async Task DeleteService_InvalidId_ReturnsRedirectToServiceList()
        {
            //Act
            //make sure you try and get invalid data 
            var result = await _controller.DeleteService(999);

            //Assert
            //make sure it knows what type i am trying to test
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            //redirect to service list because it doesnt work
            Assert.Equal("ServiceList", redirectResult.ActionName);
        }

        [Fact]
        public async Task Reports_ReturnsView()
        {
            //Act
            //controller makes sure this can retrieve valid data
            var result = await _controller.Reports();

            //Assert
            //make sure this works with valid data
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Reports_ReturnsNotFoundForInvalidPage()
        {
            //Act
            //controller does its process to make sure this works for invalid data
            var result = await _controller.Reports();

            //Assert
            //make sure it works as intended
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DownloadAllUsers_ReturnsCsvFile()
        {
            //Arrange
            //start making the list to test data
            var users = new List<Profile>
            {
                //make test data for this test case
                new Profile { Id = 101, UserId="09310293jkwadj0984", FullName = "John Doe", Email = "john.doe@example.com", CreatedAt = DateTime.Now },
                //make test data for this test case
                new Profile { Id = 102, UserId="0923rfsfwadj0984", FullName = "Jane Smith", Email = "jane.smith@example.com", CreatedAt = DateTime.Now }
            };
            //add sample data to a list 
            _context.Profiles.AddRange(users);
            //save the changes
            await _context.SaveChangesAsync();

            //Act
            //result of the controller
            var result = await _controller.DownloadAllUsers();

            //Assert
            //result of the file
            var fileResult = Assert.IsType<FileStreamResult>(result);
            //file format
            Assert.Equal("text/csv", fileResult.ContentType);
            //file name
            Assert.Equal("AllUsersReport.csv", fileResult.FileDownloadName); 

            
            using (var reader = new System.IO.StreamReader(fileResult.FileStream))
            {
                //read the file
                var fileContent = await reader.ReadToEndAsync();
                
                //data that will go in the file
                Assert.Contains("UserId, Customer Name, Email, CreatedDate", fileContent); 
                Assert.Contains("1, John Doe, john.doe@example.com", fileContent); 
                Assert.Contains("2, Jane Smith, jane.smith@example.com", fileContent); 
            }
        }

        [Fact]
        public async Task DownloadAllUsers_ReturnsEmptyCsvForNoUsers()
        {
            //Arrange
            //get the profile data for the file we need to write to
            _context.Profiles.RemoveRange(_context.Profiles);
            //save the actions
            await _context.SaveChangesAsync();

            //Act
            //let the controller do what it's supposed to do
            var result = await _controller.DownloadAllUsers();

            //Assert
            //result of the operation
            var fileResult = Assert.IsType<FileStreamResult>(result); 
            //format of the file
            Assert.Equal("text/csv", fileResult.ContentType); 
            //name of the fille
            Assert.Equal("AllUsersReport.csv", fileResult.FileDownloadName); 

            //read data from the file
            using (var reader = new System.IO.StreamReader(fileResult.FileStream))
            {
                var fileContent = await reader.ReadToEndAsync();
            
                Assert.Equal("UserId, Customer Name, Email, CreatedDate\r\n", fileContent); 
            }
        }

        [Fact]
        public async Task DownloadAllServiceProviders_ReturnsCsvFile()
        {
            //Arrange
            //make a lost of users for a test case
            var serviceProviders = new List<Profile>
            {
                //create basic user profile information
                new Profile { Id = 101, UserId="09310293jkwadj0984", FullName = "Provider 1", Role = "Provider", Address = "Address 1", PhoneNumber = "123456789" },
                //create basic user profile information
                new Profile { Id = 102, UserId="172uedlkawdhj82181", FullName = "Provider 2", Role = "Provider", Address = "Address 2", PhoneNumber = "987654321" }
            };
            //add the profiles for testing
            _context.Profiles.AddRange(serviceProviders);
            //save the changes to the file
            await _context.SaveChangesAsync();

            //Act
            //controller does its actions
            var result = await _controller.DownloadAllServiceProviders();

            //Assert
            //result you want from the file
            var fileResult = Assert.IsType<FileStreamResult>(result); 
            //file format
            Assert.Equal("text/csv", fileResult.ContentType); 
            //name of the file
            Assert.Equal("AllServiceProvidersReport.csv", fileResult.FileDownloadName);
        }

        [Fact]
        public async Task DownloadAllServiceProviders_ReturnsEmptyCsvForNoProviders()
        {
            //Arrange
            //send the provider information into the file
            _context.Profiles.RemoveRange(_context.Profiles.Where(p => p.Role == "Provider"));
            //save the changes
            await _context.SaveChangesAsync();

            //Act
            //call the controllers actions
            var result = await _controller.DownloadAllServiceProviders();

            // Assert
            var fileResult = Assert.IsType<FileStreamResult>(result);
            //make the kind of text file you desire
            Assert.Equal("text/csv", fileResult.ContentType);
            //to make the name of the CSV file
            Assert.Equal("AllServiceProvidersReport.csv", fileResult.FileDownloadName);

            //to read the content of the file
            using (var reader = new System.IO.StreamReader(fileResult.FileStream))
            {
                var fileContent = await reader.ReadToEndAsync();
                
                Assert.Equal("ProviderId, Provider Name, Address, ContactNumber\r\n", fileContent);
            }

        }
    }
}
