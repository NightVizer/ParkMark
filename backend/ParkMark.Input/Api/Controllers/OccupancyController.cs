using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/spots")]
public sealed class OccupancyController : ControllerBase
{
    [HttpPost("{spotId}/occupy")]
    [EndpointSummary("Занять место")]
    [EndpointDescription("Повтор с тем же clientEventId возвращает первый результат.")]
    [Consumes("application/json")]
    [ProducesResponseType<OccupancyResultResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "spot_not_free", "spot_unavailable", "spot_not_allowed", "booking_active", "already_occupying")]
    [ApiStub]
    public IActionResult Occupy(
        [FromRoute] Guid spotId,
        [FromBody] ManualActionRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{spotId}/release")]
    [EndpointSummary("Освободить место")]
    [EndpointDescription("Повтор с тем же clientEventId возвращает первый результат.")]
    [Consumes("application/json")]
    [ProducesResponseType<OccupancyResultResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "not_your_spot")]
    [ApiStub]
    public IActionResult Release(
        [FromRoute] Guid spotId,
        [FromBody] ManualActionRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{spotId}/night-check")]
    [EndpointSummary("Ответить на ночной запрос")]
    [EndpointDescription("Значение true в keepSpot означает «оставляю машину», false — «нет».")]
    [Consumes("application/json")]
    [ProducesResponseType<OccupancyResultResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "night_check_not_pending", "not_your_spot")]
    [ApiStub]
    public IActionResult AnswerNightCheck(
        [FromRoute] Guid spotId,
        [FromBody] NightCheckAnswerRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{spotId}/move-answer")]
    [EndpointSummary("Ответить на вопрос об освобождении места")]
    [EndpointDescription("Значение true в willMove означает «уберу машину», false — «нет».")]
    [Consumes("application/json")]
    [ProducesResponseType<OccupancyResultResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "spot_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "move_question_not_pending", "not_your_spot")]
    [ApiStub]
    public IActionResult AnswerMoveQuestion(
        [FromRoute] Guid spotId,
        [FromBody] MoveAnswerRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
