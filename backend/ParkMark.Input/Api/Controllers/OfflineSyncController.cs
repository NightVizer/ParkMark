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
    [EndpointDescription(
        "Пакет events должен быть непустым, а sequence должен возрастать. " +
        "Каждый clientEventId получает собственный результат в results. Повтор события возвращает первый результат.")]
    [Consumes("application/json")]
    [ProducesResponseType<OfflineSyncResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status400BadRequest, "validation_failed")]
    public IActionResult Sync([FromBody] OfflineSyncRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
