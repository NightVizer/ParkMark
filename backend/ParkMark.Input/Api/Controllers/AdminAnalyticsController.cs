using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/admin/analytics")]
[ApiAccess(ApiAccessLevel.Administrator)]
public sealed class AdminAnalyticsController : ControllerBase
{
    [HttpGet("occupancy")]
    [EndpointSummary("Получить аналитику занятости")]
    [EndpointDescription("occupied и available показывают занятость и доступную вместимость по этажам за интервалы. Если данных нет, возвращается 200 с пустыми рядами.")]
    [ProducesResponseType<OccupancyAnalyticsResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult GetOccupancy([FromQuery] AnalyticsQuery query) =>
        StatusCode(StatusCodes.Status501NotImplemented);

    [HttpGet("requests")]
    [EndpointSummary("Получить аналитику запросов")]
    [EndpointDescription("succeeded — число успешных броней, refusedNoSpots — число отказов «Мест нет». Если данных нет, возвращается 200 с пустыми рядами.")]
    [ProducesResponseType<RequestAnalyticsResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult GetRequests(
        [FromQuery, BindRequired] DateTimeOffset from,
        [FromQuery, BindRequired] DateTimeOffset to) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
