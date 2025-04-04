using Handyman.Controllers;
using Handyman.Data.Entities;
using Handyman.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Handyman.test
{
    public class UserControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "HandymanTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted(); // Clear database before each test run
            _context.Database.EnsureCreated();

            var userManager = new Mock<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
                null, null, null, null, null, null, null, null);

            var signInManager = new Mock<SignInManager<IdentityUser>>(
                userManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                null, null, null, null);

            var hostingEnvironment = new Mock<IWebHostEnvironment>();

            _controller = new UserController(hostingEnvironment.Object, _context, userManager.Object, signInManager.Object);
        }

        [Fact]
        public async Task DeleteProfile_ReturnsNotFound_WhenUserProfileIsNull()
        {
            // Arrange
            var userId = "testUserId";

            // Act
            var result = await _controller.DeleteProfile(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteProfile_ReturnsNotFound_WhenUserIsNull()
        {
            // Arrange
            var userId = "testUserId";
            _context.Profiles.Add(new Profile { UserId = userId });
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteProfile(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteProfile_ReturnsBadRequest_WhenDeleteUserFails()
        {
            // Arrange
            var userId = "testUserId";
            _context.Profiles.Add(new Profile { UserId = userId });
            await _context.SaveChangesAsync();

            var userManager = new Mock<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
                null, null, null, null, null, null, null, null);
            userManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(new IdentityUser { Id = userId });
            userManager.Setup(um => um.DeleteAsync(It.IsAny<IdentityUser>())).ReturnsAsync(IdentityResult.Failed());

            var signInManager = new Mock<SignInManager<IdentityUser>>(
                userManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                null, null, null, null);

            var hostingEnvironment = new Mock<IWebHostEnvironment>();

            var controller = new UserController(hostingEnvironment.Object, _context, userManager.Object, signInManager.Object);

            // Act
            var result = await controller.DeleteProfile(userId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteProfile_ReturnsRedirectToAction_WhenDeleteSucceeds()
        {
            // Arrange
            var userId = "testUserId";
            _context.Profiles.Add(new Profile { UserId = userId });
            await _context.SaveChangesAsync();

            var userManager = new Mock<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
                null, null, null, null, null, null, null, null);
            userManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(new IdentityUser { Id = userId });
            userManager.Setup(um => um.DeleteAsync(It.IsAny<IdentityUser>())).ReturnsAsync(IdentityResult.Success);

            var signInManager = new Mock<SignInManager<IdentityUser>>(
                userManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                null, null, null, null);
            signInManager.Setup(sm => sm.SignOutAsync()).Returns(Task.CompletedTask);

            var hostingEnvironment = new Mock<IWebHostEnvironment>();

            var controller = new UserController(hostingEnvironment.Object, _context, userManager.Object, signInManager.Object);

            // Act
            var result = await controller.DeleteProfile(userId);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }
        [Fact]
        public async Task GetProfileImage_ReturnsFileResult_WithProfileImage()
        {
            // Arrange
            var profileId = 1;
            var profile = new Profile
            {
                Id = profileId,
                ProfileImage = new byte[] { 1, 2, 3 } // Sample image bytes
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetProfileImage(profileId);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("image/png", fileResult.ContentType);
            Assert.Equal(profile.ProfileImage, fileResult.FileContents);
        }

        [Fact]
        public async Task GetProfileImage_ReturnsFileResult_WithDefaultImage_WhenProfileImageIsNull()
        {
            // Arrange
            var profileId = 1;
            var profile = new Profile
            {
                Id = profileId,
                ProfileImage = null
            };

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            var defaultImagePath = Path.Combine("wwwroot", "images", "defaultpic.jpg");
            var defaultImageBytes = new byte[] { 4, 5, 6 }; // Sample default image bytes
            Directory.CreateDirectory(Path.GetDirectoryName(defaultImagePath));
            await File.WriteAllBytesAsync(defaultImagePath, defaultImageBytes);

            // Act
            var result = await _controller.GetProfileImage(profileId);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal("image/jpeg", fileResult.ContentType);
            Assert.Equal(defaultImageBytes, fileResult.FileContents);
        }

    }
}
