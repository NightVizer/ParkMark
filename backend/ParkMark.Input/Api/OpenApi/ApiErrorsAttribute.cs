namespace ParkMark.Input.Api.OpenApi;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
internal sealed class ApiErrorsAttribute(int statusCode, params string[] codes) : Attribute
{
    public int StatusCode { get; } = statusCode;
    public IReadOnlyList<string> Codes { get; } = codes;
}
