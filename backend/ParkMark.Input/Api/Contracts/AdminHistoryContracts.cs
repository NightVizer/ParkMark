namespace ParkMark.Input.Api.Contracts;

public sealed record HistorySearchRequest
{
    public DateTimeOffset? From { get; init; }
    public DateTimeOffset? To { get; init; }
    public Guid? FloorId { get; init; }
    public string? Search { get; init; }
    public string? Cursor { get; init; }
    public int? Limit { get; init; }
}

public sealed record HistoryItemResponse
{
    public required Guid Id { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required string ActionType { get; init; }
    public required string Status { get; init; }
    public required string DetailKind { get; init; }
    public SpotRefDto? Spot { get; init; }
    public string? PreviousStatus { get; init; }
    public string? NewStatus { get; init; }
    public UserSummaryResponse? Initiator { get; init; }
    public string? Reason { get; init; }
}

public sealed record HistoryDetailsResponse
{
    public required HistoryItemResponse Item { get; init; }
    public UserSummaryResponse? AffectedUser { get; init; }
    public Guid? BookingId { get; init; }
    public string? RefusalReasonCode { get; init; }
    public Guid? OccupancyEventId { get; init; }
    public Guid? ResolvesHistoryId { get; init; }
    public required bool Anonymized { get; init; }
}
