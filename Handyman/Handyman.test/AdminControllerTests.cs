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
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "HandymanTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted(); // Clear database before each test run
            _context.Database.EnsureCreated();

            _controller = new AdminController(_context);
        }

        [Fact]
        public async Task Index_ReturnsViewWithCustomers_ReturnsOk()
        {
            //Arrange
            var newCustomer = new Profile
            {
                UserId = Guid.NewGuid().ToString(), // Ensure a unique ID
                Role = "Customer",
                Email = "test@example.com"
            };

            _context.Profiles.Add(newCustomer);
            _context.SaveChanges();

            //Act
            var result = await _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Profile>>(viewResult.Model);

            Assert.Contains(model, c => c.Email == "test@example.com");
        }

        [Fact]
        public async Task Index_ReturnsViewWithInvalidCustomer_ReturnsNotOk()
        {
            //Arrange
            var invalidCustomer = new Profile
            {
                UserId = null,
                Role = "Customer",
                Email = "invalid@example.com"
            };

            try
            {
                _context.Profiles.Add(invalidCustomer);
                await _context.SaveChangesAsync(); 
            }
            catch (InvalidOperationException ex)
            {
                Assert.Contains("Unable to track an entity of type 'Profile' because alternate key property 'UserId' is null", ex.Message);
                return;
            }

            Assert.True(false, "Test failed: Invalid customer was added to the database.");
        }

        [Fact]
        public async Task ServiceProviders_ReturnsViewWithInvalidProvider_ReturnsNotOk()
        {
            var invalidProvider = new Profile { UserId = null, Role = "ServiceProvider", Email = "invalid@example.com" };
            try
            {
                _context.Profiles.Add(invalidProvider);
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                Assert.Contains("Unable to track an entity of type 'Profile' because alternate key property 'UserId' is null", ex.Message);
                return;
            }
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
            var activeServiceType = new ServiceType { Id = 100, Name = "Plumbing", Description = "Fix all of the plumbing needs", IsDeleted = false };
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
              new ServiceType { Id = 1, Name = "Plumbing", Description = "Fix all of your plumbing needs", IsDeleted = true },
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
            var profile = new Profile { Id = 7, UserId = "12039ajlkdwh9021uj", FullName = "John Doe", Email = "john@example.com", Role = "Customer", Active = true };
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DeleteProfile(profile.Id);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);

            //Assert
            var deletedProfile = await _context.Profiles.FindAsync(profile.Id);
            Assert.False(deletedProfile.Active);
        }

        [Fact]
        public async Task DeleteProfile_InvalidId_ReturnsView()
        {
            //Act
            var result = await _controller.DeleteProfile(999);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ActiveProfile_ValidId_ActivatesProfile()
        {
            //Arrange
            var profile = new Profile { Id = 101, UserId = "09310293jkwadj0984", FullName = "Jane Doe", Email = "jane@example.com", Role = "Provider", Active = false };
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.ActiveProfile(profile.Id);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceProviders", redirectResult.ActionName);

            //Assert
            var activatedProfile = await _context.Profiles.FindAsync(profile.Id);
            Assert.True(activatedProfile.Active);
        }

        [Fact]
        public async Task ActiveProfile_InvalidId_ReturnsView()
        {
            //Act
            var result = await _controller.ActiveProfile(999);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DeleteService_ValidId_SoftDeletesService()
        {
            //Arrange
            var service = new Service { Id = 101, Name = "Plumbing Service", ServiceTypeId = 1, Description = "A description", Cost = 100, IsDeleted = false };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DeleteService(service.Id);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceList", redirectResult.ActionName);

            //Assert
            var deletedService = await _context.Services.FindAsync(service.Id);
            Assert.True(deletedService.IsDeleted);
        }

        [Fact]
        public async Task DeleteService_InvalidId_ReturnsRedirectToServiceList()
        {
            //Act
            var result = await _controller.DeleteService(999);

            //Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ServiceList", redirectResult.ActionName);
        }

        [Fact]
        public async Task Reports_ReturnsView()
        {
            //Act
            var result = await _controller.Reports();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Reports_ReturnsNotFoundForInvalidPage()
        {
            //Act
            var result = await _controller.Reports();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task DownloadAllUsers_ReturnsCsvFile()
        {
            //Arrange
            var users = new List<Profile>
            {
                new Profile { Id = 101, UserId="09310293jkwadj0984", FullName = "John Doe", Email = "john.doe@example.com", CreatedAt = DateTime.Now },
                new Profile { Id = 102, UserId="0923rfsfwadj0984", FullName = "Jane Smith", Email = "jane.smith@example.com", CreatedAt = DateTime.Now }
            };
            _context.Profiles.AddRange(users);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DownloadAllUsers();

            //Assert
            var fileResult = Assert.IsType<FileStreamResult>(result); 
            Assert.Equal("text/csv", fileResult.ContentType);
            Assert.Equal("AllUsersReport.csv", fileResult.FileDownloadName); 

            
            using (var reader = new System.IO.StreamReader(fileResult.FileStream))
            {
                var fileContent = await reader.ReadToEndAsync();
                
                Assert.Contains("UserId, Customer Name, Email, CreatedDate", fileContent); 
                Assert.Contains("1, John Doe, john.doe@example.com", fileContent); 
                Assert.Contains("2, Jane Smith, jane.smith@example.com", fileContent); 
            }
        }

        [Fact]
        public async Task DownloadAllUsers_ReturnsEmptyCsvForNoUsers()
        {
            //Arrange
            _context.Profiles.RemoveRange(_context.Profiles);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DownloadAllUsers();

            //Assert
            var fileResult = Assert.IsType<FileStreamResult>(result); 
            Assert.Equal("text/csv", fileResult.ContentType); 
            Assert.Equal("AllUsersReport.csv", fileResult.FileDownloadName); 

            
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
            var serviceProviders = new List<Profile>
            {
                new Profile { Id = 101, UserId="09310293jkwadj0984", FullName = "Provider 1", Role = "Provider", Address = "Address 1", PhoneNumber = "123456789" },
                new Profile { Id = 102, UserId="172uedlkawdhj82181", FullName = "Provider 2", Role = "Provider", Address = "Address 2", PhoneNumber = "987654321" }
            };
            _context.Profiles.AddRange(serviceProviders);
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DownloadAllServiceProviders();

            //Assert
            var fileResult = Assert.IsType<FileStreamResult>(result); 
            Assert.Equal("text/csv", fileResult.ContentType); 
            Assert.Equal("AllServiceProvidersReport.csv", fileResult.FileDownloadName);
        }

        [Fact]
        public async Task DownloadAllServiceProviders_ReturnsEmptyCsvForNoProviders()
        {
            //Arrange
            _context.Profiles.RemoveRange(_context.Profiles.Where(p => p.Role == "Provider"));
            await _context.SaveChangesAsync();

            //Act
            var result = await _controller.DownloadAllServiceProviders();

            // Assert
            var fileResult = Assert.IsType<FileStreamResult>(result);
            Assert.Equal("text/csv", fileResult.ContentType);
            Assert.Equal("AllServiceProvidersReport.csv", fileResult.FileDownloadName);

            
            using (var reader = new System.IO.StreamReader(fileResult.FileStream))
            {
                var fileContent = await reader.ReadToEndAsync();
                
                Assert.Equal("ProviderId, Provider Name, Address, ContactNumber\r\n", fileContent);
            }

        }
    }
}
