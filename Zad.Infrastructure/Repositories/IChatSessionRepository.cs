using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IChatSessionRepository : Zad.Application.Interfaces.Repositories.IChatSessionRepository, IGenericRepository<ChatSession>
{
}
