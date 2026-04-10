using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<IReadOnlyList<Document>> GetAllWithCategoryAsync();
    Task<IReadOnlyList<Document>> GetByCategoryAsync(int categoryId);
}
