namespace Zad.Application.DTOs;

public class CitationDto
{
    public int DocumentId { get; set; }
    public string ReferenceText { get; set; } = string.Empty;
    public string DocumentTitle { get; set; } = string.Empty;
}
