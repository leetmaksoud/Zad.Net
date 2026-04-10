using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace Zad.Application.DTOs;

/// <summary>
/// Login payload used to authenticate a user.
/// </summary>
public class LoginRequest
{
    [Required]
    [EmailAddress]
    /// <summary>
    /// User email address.
    /// </summary>
    /// <example>user@zad.app</example>
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    /// <summary>
    /// User account password.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    public string Password { get; set; } = string.Empty;
}
