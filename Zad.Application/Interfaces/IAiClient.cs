using Zad.Application.DTOs;

namespace Zad.Application.Interfaces;

public interface IAiClient
{
    Task<AiResponseDto> AskAsync(AiRequestDto request);
}
