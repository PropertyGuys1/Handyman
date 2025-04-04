using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Xunit;
using Handyman.Controllers;
using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Collections.Generic;
using Handyman.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Handyman.test
{
    public class GeminiControllerTests
    {
        private GeminiController _controller;
        private ApplicationDbContext _dbContext;
        private IServiceProvider _serviceProvider;

        public GeminiControllerTests()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dbContext = new ApplicationDbContext(options);

            // Clear database before adding new data (important when running multiple tests)
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            // Seed the database with unique services
            SeedDatabase();

            // Set up configuration (simplified for testing purposes)
            var configuration = new ConfigurationBuilder().Build();

            // Set up services for HttpClientFactory and configuration
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddHttpClient(); // Registers IHttpClientFactory

            // Build the service provider
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Get IHttpClientFactory from the service provider
            var httpClientFactory = _serviceProvider.GetRequiredService<IHttpClientFactory>();

            // Create controller with dependencies
            _controller = new GeminiController(httpClientFactory, configuration, _dbContext);
        }

        private void SeedDatabase()
        {
            // Add services with unique IDs to avoid duplicate key errors
            _dbContext.Services.Add(new Service { Id = 101, Name = "Plumbing", Description = "Fix pipes", Cost = 50 });
            _dbContext.Services.Add(new Service { Id = 102, Name = "Electrical", Description = "Fix wiring", Cost = 75 });
            _dbContext.Services.Add(new Service { Id = 103, Name = "Carpentry", Description = "Fix furniture", Cost = 100 });

            // Save changes to the in-memory database
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetServiceDescriptions_ReturnsFormattedDescriptions()
        {
            // Act
            var result = _controller.GetServiceDescriptions();

            // Assert
            var formattedDescriptions = Assert.IsType<string>(result);
            Assert.Contains("Plumbing", formattedDescriptions);
            Assert.Contains("Fix pipes", formattedDescriptions);
            Assert.Contains("$50", formattedDescriptions);
        }
    }
}

