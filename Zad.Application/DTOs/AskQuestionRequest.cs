using System.ComponentModel.DataAnnotations;
using Zad.Domain.Enums;

namespace Zad.Application.DTOs;

public class AskQuestionRequest
{
    [Required]
    [MinLength(3)]
    public string Question { get; set; } = string.Empty;

    [Required]
    [EnumDataType(typeof(ChatMode))]
    public ChatMode ChatMode { get; set; }

    [EnumDataType(typeof(ExpertSubMode))]
    public ExpertSubMode? ExpertSubMode { get; set; }

    public List<int>? ContextDocumentIds { get; set; }
}
