namespace ParkMark.Input.Api.OpenApi;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal sealed class ApiAccessAttribute(ApiAccessLevel level) : Attribute
{
    public ApiAccessLevel Level { get; } = level;
}

internal enum ApiAccessLevel
{
    Anonymous,
    Administrator
}
