using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace ParkMark.Input.Api.Contracts;

public sealed class ConflictListQuery
{
    [FromQuery(Name = "state")]
    public ConflictState? State { get; init; }

    [FromQuery(Name = "cursor")]
    public string? Cursor { get; init; }

    [FromQuery(Name = "limit")]
    public int? Limit { get; init; }
}

public sealed record ConflictResponse
{
    public required Guid HistoryId { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required string Action { get; init; }
    public required SpotRefDto Spot { get; init; }
    public UserSummaryResponse? User { get; init; }
    public required bool Resolved { get; init; }
    public ConflictResolutionDto? Resolution { get; init; }
}

public sealed record ConflictResolutionDto
{
    public required Guid HistoryId { get; init; }
    public required DateTimeOffset ResolvedAt { get; init; }
    public UserSummaryResponse? ResolvedBy { get; init; }
}

public sealed record ResolveConflictRequest
{
    public required string Reason { get; init; }
    public AdminActionKind? Correction { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter<ConflictState>))]
public enum ConflictState
{
    [JsonStringEnumMemberName("open")]
    Open,

    [JsonStringEnumMemberName("resolved")]
    Resolved
}

[JsonConverter(typeof(JsonStringEnumConverter<AdminActionKind>))]
public enum AdminActionKind
{
    Close,
    Reopen,
    Release,
    ReleaseWithoutAsking,
    Assign
}
