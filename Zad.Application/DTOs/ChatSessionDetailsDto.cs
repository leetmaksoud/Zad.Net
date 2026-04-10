namespace Zad.Application.DTOs;

/// <summary>
/// Full chat session details including messages.
/// </summary>
public class ChatSessionDetailsDto
{
    public ChatSessionDto Session { get; set; } = new();
    public List<MessageDto> Messages { get; set; } = new();
}
