using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Zad.Application.DTOs;
using Zad.Application.Interfaces;

namespace Zad.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all documents",
        Description = "Returns all knowledge base documents available to authorized users.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Documents retrieved successfully.", typeof(IReadOnlyList<DocumentDto>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Missing or invalid JWT token.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Unexpected server error.", typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IReadOnlyList<DocumentDto>>> GetDocuments()
    {
        var documents = await _documentService.GetAllDocuments();
        return Ok(documents);
    }

    [HttpGet("category/{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Get documents by category",
        Description = "Returns all documents for a specific category id.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Documents retrieved successfully.", typeof(IReadOnlyList<DocumentDto>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Missing or invalid JWT token.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No documents found for the category.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Unexpected server error.", typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IReadOnlyList<DocumentDto>>> GetDocumentsByCategory(int categoryId)
    {
        var documents = await _documentService.GetDocumentsByCategory(categoryId);
        if (documents.Count == 0)
        {
            return NotFound(new ErrorResponseDto { Message = "No documents found for this category." });
        }

        return Ok(documents);
    }

    [HttpGet("categories")]
    [SwaggerOperation(
        Summary = "Get all categories",
        Description = "Returns all available document categories.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Categories retrieved successfully.", typeof(IReadOnlyList<CategoryDto>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Missing or invalid JWT token.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Unexpected server error.", typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategories()
    {
        var categories = await _documentService.GetCategories();
        return Ok(categories);
    }
}
