namespace ParkMark.Input.Api.Contracts;

public sealed record UserSearchRequest
{
    public required string Search { get; init; }
    public string? Cursor { get; init; }
    public int? Limit { get; init; }
}

public sealed record UserSummaryResponse
{
    public required Guid Id { get; init; }
    public required string EmployeeId { get; init; }
    public required string FullName { get; init; }
    public required string Role { get; init; }
    public required string[] Tags { get; init; }
}
