namespace ParkMark.Input.Api.Contracts;

public sealed record BookingResponse
{
    public required Guid Id { get; init; }
    public required string Status { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? DeadlineAt { get; init; }
    public required bool ExtensionOffered { get; init; }
    public required bool IsVirtual { get; init; }
    public string? AlternativeAddress { get; init; }
}

public sealed record ArrivalResponse
{
    public required Guid BookingId { get; init; }
    public required SpotRefDto Spot { get; init; }
    public required DateTimeOffset AssignedAt { get; init; }
}
