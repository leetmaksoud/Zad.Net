using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IMessageRepository : Zad.Application.Interfaces.Repositories.IMessageRepository, IGenericRepository<Message>
{
}
