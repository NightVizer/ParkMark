using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/admin/conflicts")]
[ApiAccess(ApiAccessLevel.Administrator)]
public sealed class AdminConflictsController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Получить список конфликтов")]
    [EndpointDescription("Фильтр state принимает open и resolved.")]
    [ProducesResponseType<Page<ConflictResponse>>(StatusCodes.Status200OK, "application/json")]
    public IActionResult List([FromQuery] ConflictListQuery query) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{historyId}/resolve")]
    [EndpointSummary("Разрешить конфликт")]
    [EndpointDescription("correction позволяет исправить состояние места в той же операции. При автоматическом разрешении resolvedBy отсутствует или имеет значение null.")]
    [Consumes("application/json")]
    [ProducesResponseType<ConflictResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "conflict_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "conflict_already_resolved", "transition_not_allowed")]
    public IActionResult Resolve(
        [FromRoute] Guid historyId,
        [FromBody] ResolveConflictRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
