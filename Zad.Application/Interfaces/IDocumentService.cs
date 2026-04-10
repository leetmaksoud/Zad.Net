using Zad.Application.DTOs;

namespace Zad.Application.Interfaces;

public interface IDocumentService
{
    Task<IReadOnlyList<DocumentDto>> GetAllDocuments();
    Task<IReadOnlyList<DocumentDto>> GetDocumentsByCategory(int categoryId);
    Task<IReadOnlyList<CategoryDto>> GetCategories();
}
