namespace Zad.Application.DTOs;

/// <summary>
/// Request payload for creating a chat session.
/// </summary>
public class CreateChatSessionRequest
{
    /// <summary>
    /// Optional display name for the chat session.
    /// </summary>
    /// <example>Daily Fiqh Questions</example>
    public string? Name { get; set; }
}
