using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace Zad.Application.DTOs;

/// <summary>
/// Registration payload for creating a new account.
/// </summary>
public class RegisterRequest
{
    /// <summary>
    /// New user email address.
    /// </summary>
    /// <example>newuser@zad.app</example>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// New user password.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the account is for a child.
    /// </summary>
    /// <example>false</example>
    public bool IsChild { get; set; }
}
