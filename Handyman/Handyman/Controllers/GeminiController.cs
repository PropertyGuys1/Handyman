using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

[Route("api/gemini")]
[ApiController]
public class GeminiController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1/models/gemini-2.0-flash:generateContent";

    public GeminiController(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["Gemini:ApiKey"]; // Load API key from appsettings.json
    }

    [HttpPost("chat")]
    public async Task<IActionResult> Chat([FromBody] GeminiRequest request)
    {
        if (string.IsNullOrEmpty(request.Message))
        {
            return BadRequest(new { error = "Message cannot be empty" });
        }

        var requestBody = new
        {
            contents = new[]
            {
                new { parts = new[] { new { text = request.Message } } }
            }
        };

        var jsonRequest = JsonSerializer.Serialize(requestBody);
        var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiUrl}?key={_apiKey}", httpContent);
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, new { error = "Failed to connect to Gemini AI" });
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseJson);

        return Ok(new { reply = geminiResponse?.Candidates?[0]?.Content ?? "No response from AI" });
    }
}