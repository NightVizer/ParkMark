namespace ParkMark.Input.Api.Contracts;

public sealed record ManualActionRequest
{
    public required Guid ClientEventId { get; init; }
    public required DateTimeOffset DeviceCreatedAt { get; init; }
}

public sealed record NightCheckAnswerRequest
{
    public required bool KeepSpot { get; init; }
}

public sealed record MoveAnswerRequest
{
    public required bool WillMove { get; init; }
}

public sealed record OccupancyResultResponse
{
    public required string Result { get; init; }
    public required SpotRefDto Spot { get; init; }
    public required DateTimeOffset ServerTime { get; init; }
}

public sealed record OfflineSyncRequest
{
    public required OfflineEventDto[] Events { get; init; }
}

public sealed record OfflineEventDto
{
    public required Guid ClientEventId { get; init; }
    public required int Sequence { get; init; }
    public required string Action { get; init; }
    public required Guid SpotId { get; init; }
    public required DateTimeOffset DeviceCreatedAt { get; init; }
}

public sealed record OfflineSyncResponse
{
    public required OfflineEventResultDto[] Results { get; init; }
    public required DateTimeOffset ServerTime { get; init; }
}

public sealed record OfflineEventResultDto
{
    public required Guid ClientEventId { get; init; }
    public required string Result { get; init; }
    public string? ReasonCode { get; init; }
}
