namespace Zad.Application.DTOs;

/// <summary>
/// Registration payload for creating a new account.
/// </summary>
public class RegisterRequest
{
    /// <summary>
    /// New user display name.
    /// </summary>
    /// <example>New User</example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// New user email address.
    /// </summary>
    /// <example>newuser@zad.app</example>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// New user password.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Password confirmation.
    /// </summary>
    /// <example>P@ssw0rd123</example>
    public string ConfirmPassword { get; set; } = string.Empty;
}
