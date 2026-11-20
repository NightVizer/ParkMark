using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/me")]
public sealed class ProfileController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Получить текущий профиль")]
    [ProducesResponseType<ProfileResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult GetProfile() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPut("password")]
    [EndpointSummary("Сменить пароль")]
    [Consumes("application/json")]
    [ProducesResponseType<TokenPairResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status400BadRequest, "wrong_current_password")]
    [ApiErrors(StatusCodes.Status429TooManyRequests, "too_many_requests")]
    [ApiStub]
    public IActionResult ChangePassword([FromBody] ChangePasswordRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPut("login")]
    [EndpointSummary("Сменить логин")]
    [EndpointDescription("newLogin должен содержать минимум 6 символов, включая хотя бы одну букву и одну цифру.")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status400BadRequest, "validation_failed", "wrong_current_password")]
    [ApiErrors(StatusCodes.Status409Conflict, "login_taken")]
    [ApiStub]
    public IActionResult ChangeLogin([FromBody] ChangeLoginRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPut("tags/{tag}")]
    [EndpointSummary("Добавить метку пользователя")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status400BadRequest, "validation_failed")]
    [ApiStub]
    public IActionResult AddTag([FromRoute] string tag) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpDelete("tags/{tag}")]
    [EndpointSummary("Удалить метку пользователя")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiStub]
    public IActionResult RemoveTag([FromRoute] string tag) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
