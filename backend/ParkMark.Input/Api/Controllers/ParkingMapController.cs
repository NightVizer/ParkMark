using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/parking/map")]
public sealed class ParkingMapController : ControllerBase
{
    [HttpGet]
    [EndpointSummary("Получить карту парковки")]
    [EndpointDescription("availableForMe — подходящая пользователю вместимость N. Поле occupant заполняется только для администратора.")]
    [ProducesResponseType<ParkingMapResponse>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult GetMap() =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
