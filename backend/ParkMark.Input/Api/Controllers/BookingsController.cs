using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/bookings")]
public sealed class BookingsController : ControllerBase
{
    [HttpPost]
    [EndpointSummary("Создать предварительную бронь")]
    [ProducesResponseType<BookingResponse>(StatusCodes.Status201Created, "application/json")]
    [ApiErrors(StatusCodes.Status409Conflict, "no_spots", "booking_already_active", "already_occupying")]
    public IActionResult Create() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpGet("current")]
    [EndpointSummary("Получить текущую предварительную бронь")]
    [EndpointDescription("При отсутствии активной брони предусмотрен ответ 204.")]
    [ProducesResponseType<BookingResponse>(StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrent() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{bookingId}/extend")]
    [EndpointSummary("Продлить предварительную бронь")]
    [ProducesResponseType<BookingResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "booking_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "extension_not_offered", "extension_already_used", "booking_not_active")]
    public IActionResult Extend([FromRoute] Guid bookingId) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{bookingId}/arrive")]
    [EndpointSummary("Подтвердить прибытие")]
    [EndpointDescription("Повтор запроса для уже реализованной брони возвращает тот же результат с назначенным местом.")]
    [ProducesResponseType<ArrivalResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "booking_not_found")]
    [ApiErrors(StatusCodes.Status409Conflict, "no_spots", "booking_not_active")]
    public IActionResult Arrive([FromRoute] Guid bookingId) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpDelete("{bookingId}")]
    [EndpointSummary("Отменить предварительную бронь")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status404NotFound, "booking_not_found")]
    public IActionResult Cancel([FromRoute] Guid bookingId) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
