using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public sealed class AuthController : ControllerBase
{
    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("identify")]
    [EndpointSummary("Проверить ID сотрудника")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status404NotFound, "employee_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "employee_already_registered")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    public IActionResult Identify([FromBody] IdentifyRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("register")]
    [EndpointSummary("Зарегистрировать сотрудника")]
    [EndpointDescription("В ответе login равен employeeId.")]
    [Consumes("application/json")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status201Created, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "employee_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "employee_already_registered")]
    public IActionResult Register([FromBody] RegisterRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("login")]
    [EndpointSummary("Войти")]
    [EndpointDescription("В login передаётся текущий логин пользователя.")]
    [Consumes("application/json")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status401Unauthorized, "invalid_credentials")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    public IActionResult Login([FromBody] LoginRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("refresh")]
    [EndpointSummary("Обновить пару токенов")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiErrors(StatusCodes.Status401Unauthorized, "invalid_refresh_token")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    public IActionResult Refresh([FromBody] RefreshRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("logout")]
    [EndpointSummary("Завершить сессию")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Logout([FromBody] LogoutRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
