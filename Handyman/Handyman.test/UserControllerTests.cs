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
    }
}
