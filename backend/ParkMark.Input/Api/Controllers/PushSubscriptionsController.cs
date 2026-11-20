using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/push")]
public sealed class PushSubscriptionsController : ControllerBase
{
    [HttpGet("public-key")]
    [EndpointSummary("Получить открытый ключ VAPID")]
    [ProducesResponseType<PushPublicKeyResponse>(StatusCodes.Status200OK, "application/json")]
    public IActionResult GetPublicKey() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPut("subscription")]
    [EndpointSummary("Сохранить push-подписку")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Subscribe([FromBody] PushSubscribeRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("subscription/revoke")]
    [EndpointSummary("Отозвать push-подписку")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Revoke([FromBody] PushRevokeRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
