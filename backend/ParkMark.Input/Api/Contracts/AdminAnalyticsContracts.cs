using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ParkMark.Input.Api.Contracts;

public sealed class AnalyticsQuery
{
    [FromQuery(Name = "from")]
    [BindRequired]
    public DateTimeOffset From { get; init; }

    [FromQuery(Name = "to")]
    [BindRequired]
    public DateTimeOffset To { get; init; }

    [FromQuery(Name = "bucketMinutes")]
    public int? BucketMinutes { get; init; }
}

public sealed record OccupancyAnalyticsResponse
{
    public required FloorLoadDto[] Floors { get; init; }
}

public sealed record FloorLoadDto
{
    public required Guid FloorId { get; init; }
    public required string Number { get; init; }
    public required LoadBucketDto[] Buckets { get; init; }
}

public sealed record LoadBucketDto
{
    public required DateTimeOffset Start { get; init; }
    public required int Occupied { get; init; }
    public required int Available { get; init; }
}

public sealed record RequestAnalyticsResponse
{
    public required int Succeeded { get; init; }
    public required int RefusedNoSpots { get; init; }
}
