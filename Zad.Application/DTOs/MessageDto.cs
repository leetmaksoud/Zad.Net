namespace Zad.Application.DTOs;

public class MessageDto
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public List<CitationDto> Citations { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
