using Microsoft.AspNetCore.Mvc;

namespace ParkMark.Input.Api.OpenApi;

[AttributeUsage(AttributeTargets.Method)]
internal sealed class ApiStubAttribute : ProducesResponseTypeAttribute
{
    public ApiStubAttribute() : base(StatusCodes.Status501NotImplemented)
    {
        Description = "Операция пока работает как заглушка.";
    }
}
