using Microsoft.AspNetCore.Mvc;
using ParkMark.Input.Api.Contracts;
using ParkMark.Input.Api.OpenApi;

namespace ParkMark.Input.Api.Controllers;

[ApiController]
[Route("api/v1/admin/users/search")]
[ApiAccess(ApiAccessLevel.Administrator)]
public sealed class AdminUsersController : ControllerBase
{
    [HttpPost]
    [EndpointSummary("Найти сотрудников")]
    [EndpointDescription("search — поиск по ФИО или ID сотрудника.")]
    [Consumes("application/json")]
    [ProducesResponseType<Page<UserSummaryResponse>>(StatusCodes.Status200OK, "application/json")]
    [ApiStub]
    public IActionResult Search([FromBody] UserSearchRequest request) =>
        StatusCode(StatusCodes.Status501NotImplemented);
}
