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
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    public IActionResult Close(
        [FromRoute] Guid spotId,
        [FromBody] CloseSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/reopen")]
    [EndpointSummary("Открыть место")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    public IActionResult Reopen(
        [FromRoute] Guid spotId,
        [FromBody] ReopenSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/release")]
    [EndpointSummary("Освободить место администратором")]
    [EndpointDescription("Значение true в doNotAskOwner означает освобождение без вопроса владельцу.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed")]
    public IActionResult Release(
        [FromRoute] Guid spotId,
        [FromBody] AdminReleaseSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("spots/{spotId}/assign")]
    [EndpointSummary("Назначить место")]
    [EndpointDescription("При отсутствии targetUserId администратор назначает место себе.")]
    [Consumes("application/json")]
    [ProducesResponseType<AdminSpotActionResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found", "user_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "transition_not_allowed", "spot_not_allowed")]
    public IActionResult Assign(
        [FromRoute] Guid spotId,
        [FromBody] AssignSpotRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("parking/release-all")]
    [EndpointSummary("Освободить все места")]
    [Consumes("application/json")]
    [ProducesResponseType<ReleaseAllResponse>(StatusCodes.Status200OK, "application/json")]
    public IActionResult ReleaseAll([FromBody] ReleaseAllRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
