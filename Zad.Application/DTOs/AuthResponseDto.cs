namespace Zad.Application.DTOs;

/// <summary>
/// Authentication result returned after successful login or registration.
/// </summary>
public class AuthResponseDto
{
    /// <summary>
    /// JWT access token used for authorized requests.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...</example>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Authenticated user profile.
    /// </summary>
    public UserDto User { get; set; } = new();
}
