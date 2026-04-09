using Zad.Infrastructure.Repositories;

namespace Zad.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IChatSessionRepository ChatSessions { get; }
    IMessageRepository Messages { get; }
    ICitationRepository Citations { get; }
    IDocumentRepository Documents { get; }
    ICategoryRepository Categories { get; }
    IRequestLogRepository RequestLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
