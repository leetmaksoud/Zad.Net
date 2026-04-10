using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IMessageRepository : IGenericRepository<Message>
{
    Task<IReadOnlyList<Message>> GetByChatSessionAsync(int chatSessionId);
    Task<IReadOnlyList<Message>> GetUserMessagesAsync(int userId);
    Task<Message?> GetWithCitationsAsync(int messageId);
}
