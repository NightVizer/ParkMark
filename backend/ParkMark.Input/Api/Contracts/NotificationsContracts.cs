using Microsoft.AspNetCore.Mvc;

namespace ParkMark.Input.Api.Contracts;

public sealed class PageQuery
{
    [FromQuery(Name = "cursor")]
    public string? Cursor { get; init; }

    [FromQuery(Name = "limit")]
    public int? Limit { get; init; }
}

public sealed record NotificationResponse
{
    public required Guid Id { get; init; }
    public required string Type { get; init; }
    public required string Title { get; init; }
    public required string Body { get; init; }
    public string? Reason { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? ReadAt { get; init; }
    public Guid? BookingId { get; init; }
    public SpotRefDto? Spot { get; init; }
}

public sealed record NotificationListResponse
{
    public required NotificationResponse[] Items { get; init; }
    public string? NextCursor { get; init; }
}

public sealed record UnreadCountResponse
{
    public required int UnreadCount { get; init; }
}

public sealed record PushPublicKeyResponse
{
    public required string PublicKey { get; init; }
}

public sealed record PushSubscribeRequest
{
    public required string Endpoint { get; init; }
    public required string P256dh { get; init; }
    public required string Auth { get; init; }
}

public sealed record PushRevokeRequest
{
    public required string Endpoint { get; init; }
}
