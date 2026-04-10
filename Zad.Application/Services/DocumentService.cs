using AutoMapper;
using Zad.Application.DTOs;
using Zad.Application.Interfaces;

namespace Zad.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DocumentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IReadOnlyList<DocumentDto>> GetDocuments()
    {
        return GetAllDocuments();
    }

    public async Task<IReadOnlyList<DocumentDto>> GetAllDocuments()
    {
        var documents = await _unitOfWork.Documents.GetAllWithCategoryAsync();
        return _mapper.Map<IReadOnlyList<DocumentDto>>(documents);
    }

    public async Task<IReadOnlyList<DocumentDto>> GetDocumentsByCategory(int categoryId)
    {
        var documents = await _unitOfWork.Documents.GetByCategoryAsync(categoryId);
        return _mapper.Map<IReadOnlyList<DocumentDto>>(documents);
    }

    public async Task<IReadOnlyList<CategoryDto>> GetCategories()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<IReadOnlyList<CategoryDto>>(categories);
    }
}
