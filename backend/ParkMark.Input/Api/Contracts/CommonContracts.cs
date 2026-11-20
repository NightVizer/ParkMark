namespace ParkMark.Input.Api.Contracts;

public sealed record ApiProblem
{
    public required string Type { get; init; }
    public required string Title { get; init; }
    public required int Status { get; init; }
    public required string Code { get; init; }
    public required string TraceId { get; init; }
    public Dictionary<string, string[]>? Errors { get; init; }
    public string? AlternativeAddress { get; init; }
}

public sealed record Page<T>
{
    public required T[] Items { get; init; }
    public string? NextCursor { get; init; }
}
