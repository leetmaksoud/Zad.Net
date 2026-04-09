using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class RequestLogRepository : GenericRepository<RequestLog>, IRequestLogRepository
{
    public RequestLogRepository(ZadDbContext context) : base(context)
    {
    }
}
