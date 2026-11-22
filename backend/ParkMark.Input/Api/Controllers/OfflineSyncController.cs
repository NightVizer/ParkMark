using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/offline-sync")]
public sealed class OfflineSyncController : ControllerBase
{
    [HttpPost]
    [EndpointSummary("Отправить пакет офлайн-событий")]
    [EndpointDescription("Исход определяется по каждому событию: принято, отклонено или конфликт. События передаются координации в порядке sequence. Повтор с тем же clientEventId возвращает первый результат.")]
    [Consumes("application/json")]
    [ProducesResponseType<OfflineSyncResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult Submit([FromBody] OfflineSyncRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
