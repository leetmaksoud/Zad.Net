using System.ComponentModel.DataAnnotations;

namespace Zad.Application.DTOs;

public class CreateChatSessionRequest
{
    [StringLength(100)]
    public string? Name { get; set; }
}
