namespace Zad.Application.DTOs;

/// <summary>
/// Standard API error response.
/// </summary>
public class ErrorResponseDto
{
    /// <summary>
    /// Human-readable error message.
    /// </summary>
    /// <example>Chat session not found.</example>
    public string Message { get; set; } = string.Empty;
}
