using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Zad.Infrastructure.Repositories;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ZadDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Document>> GetAllWithCategoryAsync()
    {
        return await Context.Documents
            .Include(x => x.Category)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Document>> GetByCategoryAsync(int categoryId)
    {
        return await Context.Documents
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
    }
}
