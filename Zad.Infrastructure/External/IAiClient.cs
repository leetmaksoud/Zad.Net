using Zad.Application.DTOs;

namespace Zad.Infrastructure.External;

public interface IAiClient
{
    Task<AiResponseDto> AskAsync(AiRequestDto request);
}
