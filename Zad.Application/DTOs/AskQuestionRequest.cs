using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using Zad.Domain.Enums;

namespace Zad.Application.DTOs;

/// <summary>
/// Request payload for asking a question to the AI service.
/// </summary>
public class AskQuestionRequest
{
    /// <summary>
    /// The user question text.
    /// </summary>
    /// <example>What is the ruling on zakat for gold savings?</example>
    [Required]
    [MinLength(3)]
    public string Question { get; set; } = string.Empty;

    /// <summary>
    /// Chat response mode.
    /// </summary>
    /// <example>1</example>
    [Required]
    [EnumDataType(typeof(ChatMode))]
    public ChatMode ChatMode { get; set; }

    /// <summary>
    /// Optional expert sub-mode for specialized responses.
    /// </summary>
    /// <example>1</example>
    [EnumDataType(typeof(ExpertSubMode))]
    public ExpertSubMode? ExpertSubMode { get; set; }

    /// <summary>
    /// Optional knowledge base document identifiers to prioritize context.
    /// </summary>
    /// <example>[1,2]</example>
    public List<int>? ContextDocumentIds { get; set; }
}
