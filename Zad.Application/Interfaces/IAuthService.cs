using Zad.Application.DTOs;

namespace Zad.Application.Interfaces;

public interface IAuthService
{
    Task<UserDto> Register(RegisterRequest request);
    Task<string> Login(string email, string password);
    Task<UserDto?> GetByEmail(string email);
}
