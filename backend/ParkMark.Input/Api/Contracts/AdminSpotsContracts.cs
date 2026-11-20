namespace ParkMark.Input.Api.Contracts;

public sealed record CloseSpotRequest
{
    public required string Reason { get; init; }
}

public sealed record ReopenSpotRequest
{
    public required string Reason { get; init; }
}

public sealed record AdminReleaseSpotRequest
{
    public required string Reason { get; init; }
    public required bool DoNotAskOwner { get; init; }
}

public sealed record AssignSpotRequest
{
    public Guid? TargetUserId { get; init; }
    public required string Reason { get; init; }
}

public sealed record AdminSpotActionResponse
{
    public required SpotDto Spot { get; init; }
    public required Guid HistoryId { get; init; }
    public required bool OwnerNotified { get; init; }
}

public sealed record ReleaseAllRequest
{
    public required string Reason { get; init; }
}

public sealed record ReleaseAllResponse
{
    public required int ReleasedCount { get; init; }
}
