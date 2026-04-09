using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IChatSessionRepository : IGenericRepository<ChatSession>
{
    Task<IReadOnlyList<ChatSession>> GetUserSessions(int userId);
    Task<ChatSession?> GetWithMessages(int chatSessionId);
}
