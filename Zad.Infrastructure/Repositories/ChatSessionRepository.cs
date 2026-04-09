using Microsoft.EntityFrameworkCore;
using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class ChatSessionRepository : GenericRepository<ChatSession>, IChatSessionRepository
{
    public ChatSessionRepository(ZadDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<ChatSession>> GetUserSessions(int userId)
    {
        return await Context.ChatSessions
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<ChatSession?> GetWithMessages(int chatSessionId)
    {
        return await Context.ChatSessions
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == chatSessionId);
    }
}
