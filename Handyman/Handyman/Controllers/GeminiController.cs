using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Handyman.Controllers
{
    [Route("Gemini")]
    [ApiController]
    public class GeminiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GeminiController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("Chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            string response = await GetGeminiResponse(request.Prompt);
            return Json(new { response });
        }

        private async Task<string> GetGeminiResponse(string prompt)
        {
            var apiKey = _configuration["Gemini:ApiKey"];
            var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

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
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }

    public class ChatRequest
    {
        public string Prompt { get; set; }
    }
}