using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/push")]
public sealed class PushSubscriptionsController : ControllerBase
{
    [HttpGet("public-key")]
    [EndpointSummary("Получить открытый ключ VAPID")]
    [EndpointDescription("Открытый ключ берётся из конфигурации.")]
    [ProducesResponseType<PushPublicKeyResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult GetPublicKey() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPut("subscription")]
    [EndpointSummary("Сохранить push-подписку")]
    [EndpointDescription("Подписка устройства. Повтор с тем же endpoint не создаёт дубль.")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiStub]
    public IActionResult Subscribe([FromBody] PushSubscribeRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("subscription/revoke")]
    [EndpointSummary("Отозвать push-подписку")]
    [EndpointDescription("Пользователь отключил push. При выходе подписку отзывает Logout.")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiStub]
    public IActionResult Revoke([FromBody] PushRevokeRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
