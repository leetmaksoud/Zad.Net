using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<IReadOnlyList<Message>> GetByChatSession(int chatSessionId);
    Task<Message?> GetWithCitations(int messageId);
}
