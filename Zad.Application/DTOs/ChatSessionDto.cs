namespace Zad.Application.DTOs;

public class ChatSessionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public int MessageCount { get; set; }
}
