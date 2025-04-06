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
