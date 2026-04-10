using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<IReadOnlyList<Message>> GetByChatSession(int chatSessionId);
    Task<Message?> GetWithCitations(int messageId);
}
