using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using Handyman.Data;
using System.Linq;

namespace Handyman.Controllers
{
    [Route("Gemini")]
    [ApiController]
    public class GeminiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;

        public GeminiController(IHttpClientFactory httpClientFactory, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("Chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            string serviceInfo = GetServiceDescriptions();
            string fullPrompt = BuildPrompt(request.Prompt, serviceInfo);

            string rawResponse = await GetGeminiResponse(fullPrompt);
            string extractedResponse = ExtractTextFromResponse(rawResponse);

            return Json(new { response = extractedResponse });
        }

        private async Task<string> GetGeminiResponse(string prompt)
        {
            var apiKey = _configuration["Gemini:ApiKey"];
            var apiUrl = $"https://generativelanguage.googleapis.com/v1/models/gemini-2.0-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = prompt } } }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync(apiUrl, content);
            return await response.Content.ReadAsStringAsync();
        }

        private string ExtractTextFromResponse(string jsonResponse)
        {
            try
            {
                var parsedJson = JsonNode.Parse(jsonResponse);
                return parsedJson?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString() ?? "No response";
            }
            catch
            {
                return "Error processing response";
            }
        }

        private string GetServiceDescriptions()
        {
            var services = _dbContext.Services
                .Select(s => $"{s.Name}: {s.Description}. Price: ${s.Cost}")
                .ToList();

            return string.Join("\n", services);
        }

        private string BuildPrompt(string userInput, string serviceInfo)
        {
            return $"""
            You are a helpful and professional AI assistant for a handyman company.
            You provide customers with useful information about the available services.

            Here are the services currently offered:
            {serviceInfo}

            When answering, ensure that you provide only relevant information based on the listed services.
            Do not make up services.
            Take some limited liberty to explain what the service would include.
            If asked for more details about a specific service, you may use common knowledge about the specific service.
            Unless addressing a specific question or for the sake of politeness/professionalism, keep your response under 20 words.

            User: {userInput}
            """;
        }
    }

    public class ChatRequest
    {
        public string Prompt { get; set; }
    }
}
