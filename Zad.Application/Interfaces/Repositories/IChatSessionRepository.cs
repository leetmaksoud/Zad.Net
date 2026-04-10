using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IChatSessionRepository : IGenericRepository<ChatSession>
{
    Task<IReadOnlyList<ChatSession>> GetUserSessions(int userId);
    Task<ChatSession?> GetWithMessages(int chatSessionId);
}
