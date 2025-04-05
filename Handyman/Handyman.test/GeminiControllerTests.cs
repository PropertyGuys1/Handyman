using Handyman.Controllers;
using Handyman.Data.Entities;
using Handyman.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace Handyman.test
{
    public class GeminiControllerTests
    {
        //private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        //private readonly Mock<IConfiguration> _configurationMock;
        //private readonly Mock<ApplicationDbContext> _dbContextMock;
        //private readonly GeminiController _controller;

        //public GeminiControllerTests()
        //{
        //    _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        //    _configurationMock = new Mock<IConfiguration>();
        //    _dbContextMock = new Mock<ApplicationDbContext>();

        //    _controller = new GeminiController(_httpClientFactoryMock.Object, _configurationMock.Object, _dbContextMock.Object);
        //}

        [Fact]
        public async Task Chat_ReturnsExpectedResponse()
        {
            //// Arrange
            //var chatRequest = new ChatRequest { Prompt = "Tell me about your services" };
            //var serviceDescriptions = "Service1: Description1. Price: $100\nService2: Description2. Price: $200";
            //var fullPrompt = $"""
            //You are a helpful and professional AI assistant for a handyman company.
            //You provide customers with useful information about the available services.

            //Here are the services currently offered:
            //{serviceDescriptions}

            //When answering, ensure that you provide only relevant information based on the listed services.
            //Do not make up services.
            //Take some limited liberty to explain what the service would include.
            //If asked for more details about a specific service, you may use common knowledge about the specific service.
            //Unless addressing a specific question or for the sake of politeness/professionalism, keep your response under 20 words.

            //User: {chatRequest.Prompt}
            //""";

            //var httpClientMock = new Mock<HttpMessageHandler>();
            //httpClientMock
            //    .Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new HttpResponseMessage
            //    {
            //        StatusCode = System.Net.HttpStatusCode.OK,
            //        Content = new StringContent(JsonSerializer.Serialize(new { candidates = new[] { new { content = new { parts = new[] { new { text = "Service details" } } } } } }))
            //    });

            //var client = new HttpClient(httpClientMock.Object);
            //_httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            //_configurationMock.SetupGet(c => c["Gemini:ApiKey"]).Returns("fake-api-key");

            //_dbContextMock.Setup(db => db.Services).Returns(new List<Service>
            //{
            //    new Service { Name = "Service1", Description = "Description1", Cost = 100 },
            //    new Service { Name = "Service2", Description = "Description2", Cost = 200 }
            //}.AsQueryable());

            //// Act
            //var result = await _controller.Chat(chatRequest) as JsonResult;
            //var response = result?.Value as dynamic;

            //// Assert
            //Assert.NotNull(response);
            //Assert.Equal("Service details", response.response);
        }
        [Fact]
        public async Task Chat_ReturnsUnexpectedResponse()
        { }
        [Fact]
        public async Task Chat_ReturnsUnexpectedResponse2()
        { }
        [Fact]
        public async Task Chat_ReturnsUnexpectedResponse3()
        { }
    }
}
