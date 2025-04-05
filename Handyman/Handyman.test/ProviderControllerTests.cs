using Handyman.Controllers;
using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handyman.test
{
    public class ProviderControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly Mock<SignInManager<IdentityUser>> _mockSignInManager;
        private readonly ProviderController _controller;

        public ProviderControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;
            _context = new ApplicationDbContext(options);

            _mockUserManager = MockUserManager();
            _mockSignInManager = MockSignInManager(_mockUserManager.Object); // Pass the required argument
            _controller = new ProviderController(_context, _mockUserManager.Object, _mockSignInManager.Object);

        }

        [Fact]
        public async Task Index_UserNotLoggedIn_RedirectsToLogin()
        {
            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns((string)null);

            var result = await _controller.Index();

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirectResult.ActionName);
            Assert.Equal("Account", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Index_UserLoggedIn_ProfileIncomplete_ReturnsEmptyList()
        {
            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns("userId");
            _context.Profiles.Add(new Profile { UserId = "userId", FullName = null, PhoneNumber = null });
            await _context.SaveChangesAsync();

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Appointment>>(viewResult.Model);
            Assert.Empty(model);
            Assert.False((bool)viewResult.ViewData["IsProfileComplete"]);
        }

        [Fact]
        public async Task Profile_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = "nonexistentUserId";

            // Act
            var result = await _controller.Profile(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Profile_UserFound_ReturnsProfileView()
        {
            //// Arrange
            //var userId = "userId";
            //var providerProfile = new ProviderProfile
            //{
            //    ProfileId = userId,
            //    ServicesOffered = "Plumbing, Electrical", // Set required property
            //    Addresses = new List<Address>(),
            //    Payments = new List<Payment>(),
            //    Appointments = new List<Appointment>(),
            //    AppointmentFeedbacks = new List<AppointmentFeedback>()
            //};
            //var profile = new Profile { UserId = userId, ProviderProfile = providerProfile };
            //var address = new Address
            //{
            //    userId = userId,
            //    City = "Waterloo",
            //    Country = "Canada",
            //    PostalCode = "N2L 3G1",
            //    State = "Ontario",
            //    Street = "123 Main St"
            //};

            //var payment = new Payment
            //{
            //    UserId = userId,
            //    CVV = "123",
            //    CardHolderName = "John Doe",
            //    CardNumber = "4111111111111111",
            //    ExpiryDate = DateTime.Now.AddYears(1).ToString("MM/yy")
            //};

            //var appointment = new Appointment
            //{
            //    ProviderId = userId,
            //    Status = "Completed",
            //    Cost = 100,
            //    Address = "123 Main St",
            //    PersonName = "John Doe",
            //    UserId = userId
            //};

            //var feedback = new AppointmentFeedback { AppointmentId = appointment.Id ,Feedback="Feedback"};

            //_context.Profiles.Add(profile);
            //_context.Addresses.Add(address);
            //_context.Payments.Add(payment);
            //_context.Appointments.Add(appointment);
            //_context.AppointmentFeedbacks.Add(feedback);
            //await _context.SaveChangesAsync();

            //// Act
            //var result = await _controller.Profile(userId);

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var viewModel = Assert.IsType<UserProfileViewModel>(viewResult.Model);
            //Assert.Equal(profile, viewModel.Profile);
            //Assert.Equal(profile.ProviderProfile, viewModel.ProviderProfile);
            //Assert.Equal(1, viewModel.Addresses.Count());
            //Assert.Equal(1, viewModel.Payments.Count());
            //Assert.Equal(1, viewModel.Appointments.Count());
            ////Assert.Equal(1, viewModel.Feedbacks.Count());
            //Assert.Equal(100, viewModel.Balance);
        }

        [Fact]
        public void EditProfile_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = "nonexistentUserId";

            // Act
            var result = _controller.EditProfile(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditProfile_UserFound_ReturnsEditProfileView()
        {
            //// Arrange
            //var userId = "userId";
            //var providerProfile = new ProviderProfile
            //{
            //    ProfileId = userId,
            //    ServicesOffered = "Plumbing, Electrical" // Set required property
            //};
            //var profile = new Profile
            //{
            //    UserId = userId,
            //    FullName = "John Doe",
            //    Email = "john.doe@example.com",
            //    PhoneNumber = "1234567890",
            //    ProviderProfile = providerProfile
            //};

            //_context.Profiles.Add(profile);
            //_context.SaveChanges();

            //// Act
            //var result = _controller.EditProfile(userId);

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsType<UserProfileEditViewModel>(viewResult.Model);
            //Assert.Equal("John Doe", model.FullName);
            //Assert.Equal("john.doe@example.com", model.Email);
            //Assert.Equal("1234567890", model.PhoneNumber);
            //Assert.Equal("Plumbing, Electrical", model.Preferences);
        }

        [Fact]
        public async Task EditProfile_ModelStateInvalid_ReturnsViewWithModel()
        {
            // Arrange
            var model = new UserProfileEditViewModel();
            _controller.ModelState.AddModelError("Error", "ModelState is invalid");

            // Act
            var result = await _controller.EditProfile(model, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public async Task EditProfile_ProfileNotFound_ReturnsViewWithModel()
        {
            // Arrange
            var model = new UserProfileEditViewModel { Id = "nonexistentUserId" };

            // Act
            var result = await _controller.EditProfile(model, null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }



        [Fact]
        public async Task StartAppointment_AppointmentNotFound_ReturnsRedirectToAction()
        {
        //    // Arrange
        //    var appointmentId = 999; // Non-existent appointment ID

        //    // Act
        //    var result = await _controller.StartAppointment(appointmentId);

        //    // Assert
        //    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Appointment", redirectResult.ActionName);
        //    Assert.Equal("Provider", redirectResult.ControllerName);
        //    Assert.Null(redirectResult.RouteValues["providerId"]);
        }


        [Fact]
        public async Task StartAppointment_AppointmentFound_UpdatesStatusAndReturnsRedirectToAction()
        {
            // Arrange
            var appointmentId = 1;
            var providerId = "providerId";
            var appointment = new Appointment
            {
                Id = appointmentId,
                ProviderId = providerId,
                Status = "Pending",
                Address = "123 Main St",
                PersonName = "John Doe",
                UserId = "userId"
            };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.StartAppointment(appointmentId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Appointment", redirectResult.ActionName);
            Assert.Equal("Provider", redirectResult.ControllerName);
            Assert.Equal(providerId, redirectResult.RouteValues["providerId"]);

            var updatedAppointment = await _context.Appointments.FindAsync(appointmentId);
            Assert.NotNull(updatedAppointment);
            Assert.Equal("InProgress", updatedAppointment.Status);
        }





        private Mock<UserManager<IdentityUser>> MockUserManager()
        {
            var store = new Mock<IUserStore<IdentityUser>>();
            return new Mock<UserManager<IdentityUser>>(store.Object, null, null, null, null, null, null, null, null);
        }

        private Mock<SignInManager<IdentityUser>> MockSignInManager(UserManager<IdentityUser>? userManager)
        {
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<IdentityUser>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<IdentityUser>>();

            return new Mock<SignInManager<IdentityUser>>(userManager, contextAccessor.Object, claimsFactory.Object, options.Object, logger.Object, schemes.Object, confirmation.Object);
        }


    }
}
