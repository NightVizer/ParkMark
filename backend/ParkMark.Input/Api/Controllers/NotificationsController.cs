using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/notifications")]
public sealed class NotificationsController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Получить уведомления текущего пользователя")]
    [ProducesResponseType<NotificationListResponse>(StatusCodes.Status200OK, "application/json")]
    public IActionResult List([FromQuery] PageQuery query) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpGet("unread-count")]
    [EndpointSummary("Получить число непрочитанных уведомлений")]
    [ProducesResponseType<UnreadCountResponse>(StatusCodes.Status200OK, "application/json")]
    public IActionResult GetUnreadCount() =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpGet("{notificationId}")]
    [EndpointSummary("Получить уведомление")]
    [ProducesResponseType<NotificationResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiErrors(StatusCodes.Status404NotFound, "notification_not_found")]
    public IActionResult GetNotification([FromRoute] Guid notificationId) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpPost("{notificationId}/read")]
    [EndpointSummary("Отметить уведомление прочитанным")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ApiErrors(StatusCodes.Status404NotFound, "notification_not_found")]
    public IActionResult MarkRead([FromRoute] Guid notificationId) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
