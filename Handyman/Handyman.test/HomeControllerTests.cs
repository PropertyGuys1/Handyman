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
            var mockEmailHelper = new Mock<EmailHelper>();
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
            var mockEmailHelper = new Mock<EmailHelper>();
            var controller = new HomeController(null, mockEmailHelper.Object);

            // Act
            var result = await controller.GetServices("");

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var services = Assert.IsType<List<string>>(jsonResult.Value);
            Assert.Empty(services);
        }

        [Fact]
        public async Task GetServices_ReturnsMatchingServices_WhenQueryMatches()

        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Services.AddRange(
                new Service { Id = 1, Name = "Plumbing" },
                new Service { Id = 2, Name = "Electrical" },
                new Service { Id = 3, Name = "Painting" }
            );
            context.SaveChanges();

            var mockEmailHelper = new Mock<EmailHelper>();
            var controller = new HomeController(context, mockEmailHelper.Object);

            // Act
            var result = await controller.GetServices("plumb");

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            var services = jsonResult.Value as IEnumerable<dynamic>;
            Assert.NotNull(services);
            var service = services.First();
            Assert.Equal(1, (int)service.GetType().GetProperty("Id").GetValue(service));
            Assert.Equal("Plumbing", (string)service.GetType().GetProperty("Name").GetValue(service));
             }

        [Fact]
        public async Task Services_ReturnsViewWithServiceTypes()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.ServiceTypes.AddRange(
                new ServiceType { Id = 1, Name = "Plumbing" },
                new ServiceType { Id = 2, Name = "Electrical" }
            );
            context.SaveChanges();

            var mockEmailHelper = new Mock<EmailHelper>();
            var controller = new HomeController(context, mockEmailHelper.Object);

            // Act
            var result = await controller.Services();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ServiceType>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public async Task Services_ReturnsEmptyList_WhenNoServiceTypes()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var mockEmailHelper = new Mock<EmailHelper>();
            var controller = new HomeController(context, mockEmailHelper.Object);

            // Act
            var result = await controller.Services();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ServiceType>>(viewResult.Model);
            Assert.Empty(model);
        }
        [Fact]
        public async Task Services_IncludesRelatedServices()
        {

            // Arrange
            var context = GetInMemoryDbContext();
            var plumbing = new ServiceType { Id = 3, Name = "Plumbing" };
            var electrical = new ServiceType { Id = 4, Name = "Electrical" };
            context.ServiceTypes.AddRange(plumbing, electrical);
            context.Services.AddRange(
                new Service { Id = 3, Name = "Pipe Repair", ServiceTypeId = plumbing.Id },
                new Service { Id = 4, Name = "Wiring", ServiceTypeId = electrical.Id }
            );
            context.SaveChanges();

            var mockEmailHelper = new Mock<EmailHelper>();
            var controller = new HomeController(context, mockEmailHelper.Object);

            // Act
            var result = await controller.Services();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ServiceType>>(viewResult.Model);
            var plumbingResult = model.FirstOrDefault(st => st.Name == "Plumbing");
            var electricalResult = model.FirstOrDefault(st => st.Name == "Electrical");
            Assert.NotNull(plumbingResult);
            Assert.NotNull(electricalResult);
            Assert.Single(plumbingResult.Services);
            Assert.Single(electricalResult.Services);
            Assert.Equal("Pipe Repair", plumbingResult.Services.First().Name);
            Assert.Equal("Wiring", electricalResult.Services.First().Name);

        }
        [Fact]
        public void Contact_ReturnsViewResult()
        {
            // Arrange
            var mockEmailHelper = new Mock<EmailHelper>();
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
            var mockEmailHelper = new Mock<EmailHelper>();
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
