using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Zad.Application.DTOs;
using Zad.Application.Interfaces;

namespace Zad.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Register a new user",
        Description = "Creates a new account and returns a JWT token with user profile data.")]
    [SwaggerResponse(StatusCodes.Status201Created, "User registered successfully.", typeof(AuthResponseDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation error.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Unexpected server error.", typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterRequest request)
    {
        var user = await _authService.Register(request.Email, request.Password, request.IsChild);
        var token = await _authService.Login(request.Email, request.Password);

        var response = new AuthResponseDto
        {
            Token = token,
            User = user
        };

        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Login with email and password",
        Description = "Authenticates the user and returns a JWT token.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Login successful.", typeof(AuthResponseDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid credentials.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation error.", typeof(ErrorResponseDto))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Unexpected server error.", typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequest request)
    {
        var token = await _authService.Login(request.Email, request.Password);
        var user = await _authService.GetByEmail(request.Email);
        if (user is null)
        {
            return Unauthorized(new ErrorResponseDto { Message = "Invalid email or password." });
        }

        return Ok(new AuthResponseDto
        {
            Token = token,
            User = user
        });
    }
}
