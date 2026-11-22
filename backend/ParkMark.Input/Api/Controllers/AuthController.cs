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
    [EndpointDescription("ID должен быть в списке сотрудников, заданном в коде.")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status404NotFound, "employee_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "employee_already_registered")]
    [ApiStub]
    public IActionResult Identify([FromBody] IdentifyRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("register")]
    [EndpointSummary("Зарегистрировать сотрудника")]
    [EndpointDescription("Пользователь сам вводит ФИО и пароль. В ответе профиль и пара токенов, login по умолчанию равен employeeId.")]
    [Consumes("application/json")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status201Created, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "employee_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "employee_already_registered")]
    [ApiStub]
    public IActionResult Register([FromBody] RegisterRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("login")]
    [EndpointSummary("Войти")]
    [EndpointDescription("В login передаётся ID сотрудника или сменённый логин.")]
    [Consumes("application/json")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status401Unauthorized, "invalid_credentials")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    [ApiStub]
    public IActionResult Login([FromBody] LoginRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [ApiAccess(ApiAccessLevel.Anonymous)]
    [HttpPost("refresh")]
    [EndpointSummary("Обновить пару токенов")]
    [Consumes("application/json")]
    [ProducesResponseType<TokenPairResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status401Unauthorized, "invalid_refresh_token")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    [ApiStub]
    public IActionResult Refresh([FromBody] RefreshRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("logout")]
    [EndpointSummary("Завершить сессию")]
    [EndpointDescription("Refresh-токен отзывается, push-подписка этого устройства отзывается в той же операции.")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiStub]
    public IActionResult Logout([FromBody] LogoutRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
