using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Zad.Application.DTOs;

namespace Zad.Infrastructure.External;

public class AiClient : IAiClient
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly HttpClient _httpClient;
    private readonly AiClientOptions _options;
    private readonly ILogger<AiClient> _logger;

    public AiClient(HttpClient httpClient, IOptions<AiClientOptions> options, ILogger<AiClient> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<AiResponseDto> AskAsync(AiRequestDto request)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/ask")
        {
            Content = JsonContent.Create(request)
        };

        httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (!string.IsNullOrWhiteSpace(_options.ApiKey))
        {
            httpRequest.Headers.TryAddWithoutValidation("X-Api-Key", _options.ApiKey);
        }

        try
        {
            using var response = await _httpClient.SendAsync(httpRequest);

            if (response.StatusCode == HttpStatusCode.RequestTimeout)
            {
                throw new TimeoutException("The AI service request timed out.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("AI service request failed with status {StatusCode}. Response: {Response}", (int)response.StatusCode, errorContent);
                throw new HttpRequestException($"AI service request failed with status code {(int)response.StatusCode}.");
            }

            var result = await response.Content.ReadFromJsonAsync<AiResponseDto>(JsonSerializerOptions);

            return result ?? throw new InvalidOperationException("AI service returned an empty response body.");
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "AI service request timed out.");
            throw new TimeoutException("The AI service request timed out.", ex);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "AI service request failed.");
            throw;
        }
    }
}
