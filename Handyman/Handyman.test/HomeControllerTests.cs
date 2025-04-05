using Handyman.Controllers;
using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.Helper;
using Handyman.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Handyman.test
{
    public class HomeControllerTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "HandymanTestDb")
                .Options;
            return new ApplicationDbContext(options);
        }


        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var mockEmailHelper = new Mock<IEmailHelper>();
            var controller = new HomeController(null, mockEmailHelper.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }
        [Fact]
        public async Task GetServices_ReturnsEmptyList_WhenQueryIsEmpty()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var mockEmailHelper = new Mock<IEmailHelper>();
            var controller = new HomeController(null, mockEmailHelper.Object);

            // Act
            var result = await controller.GetServices("");

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var services = Assert.IsType<List<string>>(jsonResult.Value);
            Assert.Empty(services);
        }
        
        [Fact]
        public void Contact_ReturnsViewResult()
        {
            // Arrange
            var mockEmailHelper = new Mock<IEmailHelper>();
            var controller = new HomeController(null, mockEmailHelper.Object);

            // Act
            var result = controller.Contact();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }

        [Fact]
        public async Task Contact_ReturnsViewWithModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockEmailHelper = new Mock<IEmailHelper>();
            var controller = new HomeController(null, mockEmailHelper.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var model = new ContactViewModel();

            // Act
            var result = await controller.Contact(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public async Task Contact_ReturnsViewWithSuccessMessage_WhenEmailSentSuccessfully()
        {
            // Arrange
            var mockEmailHelper = new Mock<IEmailHelper>();
            mockEmailHelper.Setup(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);
            var controller = new HomeController(null, mockEmailHelper.Object);
            var model = new ContactViewModel { Name = "John", Email = "john@example.com", Subject = "Test", Message = "Hello" };

            // Act
            var result = await controller.Contact(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
            Assert.Equal("Thank you for contacting us!", controller.ViewBag.Message);
        }

        [Fact]
        public async Task Contact_ReturnsViewWithErrorMessage_WhenEmailSendingFails()
        {
            // Arrange
            var mockEmailHelper = new Mock<IEmailHelper>();
            mockEmailHelper.Setup(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("SMTP error"));
            var controller = new HomeController(null, mockEmailHelper.Object);
            var model = new ContactViewModel { Name = "John", Email = "john@example.com", Subject = "Test", Message = "Hello" };

            // Act
            var result = await controller.Contact(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
            Assert.Equal("Error sending email: SMTP error", controller.ViewBag.ErrorMessage);
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null, null);

            // Act
            var result = controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }
        [Fact]
        public void Terms_ReturnsViewResult()
        {
            // Arrange
            var controller = new HomeController(null, null);

            // Act
            var result = controller.Terms();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view name
        }

    }
}
