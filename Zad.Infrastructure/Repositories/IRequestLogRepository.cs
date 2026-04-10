using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IRequestLogRepository : Zad.Application.Interfaces.Repositories.IRequestLogRepository, IGenericRepository<RequestLog>
{
}
