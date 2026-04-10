using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IChatSessionRepository : IGenericRepository<ChatSession>
{
    Task<IReadOnlyList<ChatSession>> GetUserSessionsAsync(int userId);
    Task<ChatSession?> GetWithMessagesAsync(int chatSessionId);
}
