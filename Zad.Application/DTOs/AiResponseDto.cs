namespace Zad.Application.DTOs;

public class AiResponseDto
{
    public string Answer { get; set; } = string.Empty;
    public List<AiCitationDto> Citations { get; set; } = new();
}
