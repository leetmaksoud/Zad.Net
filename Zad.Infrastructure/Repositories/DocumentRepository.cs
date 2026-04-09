using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ZadDbContext context) : base(context)
    {
    }
}
