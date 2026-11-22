using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/admin")]
[ApiAccess(ApiAccessLevel.Administrator)]
public sealed class AdminSpotsController : ControllerBase
{
    [HttpPost("spots/{spotId}/close")]
    [EndpointSummary("Закрыть место")]
    [EndpointDescription("Причина обязательна (FR-34): без неё 400 validation_failed.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    [ApiStub]
    public IActionResult Close(
        [FromRoute] Guid spotId,
        [FromBody] CloseSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/reopen")]
    [EndpointSummary("Открыть место")]
    [EndpointDescription("Возвращает место в работу. Причина обязательна (FR-34): без неё 400 validation_failed.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    [ApiStub]
    public IActionResult Reopen(
        [FromRoute] Guid spotId,
        [FromBody] ReopenSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/release")]
    [EndpointSummary("Освободить место администратором")]
    [EndpointDescription("По умолчанию владельцу уходит вопрос, уберёт ли он машину. Значение true в doNotAskOwner означает освобождение без вопроса (место на карте занято, а физически пустое). Пока владелец не ответил, место остаётся занятым, ответ приходит администратору уведомлением. Причина обязательна (FR-34): без неё 400 validation_failed.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    [ApiStub]
    public IActionResult Release(
        [FromRoute] Guid spotId,
        [FromBody] AdminReleaseSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/assign")]
    [EndpointSummary("Назначить место")]
    [EndpointDescription("Назначает место себе или сотруднику. При отсутствии targetUserId администратор назначает место себе. Причина обязательна (FR-34): без неё 400 validation_failed.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found", "user_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed", "spot_not_allowed")]
    [ApiStub]
    public IActionResult Assign(
        [FromRoute] Guid spotId,
        [FromBody] AssignSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("parking/release-all")]
    [EndpointSummary("Освободить все места")]
    [EndpointDescription("Освобождает все занятые места парковки. Тем, кто их занимал, отправляется уведомление, брони не сбрасываются. Причина обязательна: без неё 400 validation_failed.")]
    [Consumes("application/json")]
    [ProducesResponseType<ReleaseAllResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult ReleaseAll([FromBody] ReleaseAllRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
