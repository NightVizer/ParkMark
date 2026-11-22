using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/admin/history")]
[ApiAccess(ApiAccessLevel.Administrator)]
public sealed class AdminHistoryController : ControllerBase
{
    [HttpPost("search")]
    [EndpointSummary("Найти записи в истории")]
    [EndpointDescription("Если записей нет, items пуст.")]
    [Consumes("application/json")]
    [ProducesResponseType<Page<HistoryItemResponse>>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult Search([FromBody] HistorySearchRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpGet("{historyId}")]
    [EndpointSummary("Получить детали записи истории")]
    [EndpointDescription("После обезличивания anonymized имеет значение true, а поля с личностью пусты.")]
    [ProducesResponseType<HistoryDetailsResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "history_not_found")]
    [ApiStub]
    public IActionResult Get([FromRoute] Guid historyId) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
