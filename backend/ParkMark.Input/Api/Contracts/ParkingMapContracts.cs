namespace ParkMark.Input.Api.Contracts;

public sealed record ParkingMapResponse
{
    public required Guid ParkingId { get; init; }
    public required string Name { get; init; }
    public required DateTimeOffset ServerTime { get; init; }
    public required int AvailableForMe { get; init; }
    public required FloorDto[] Floors { get; init; }
    public required MyStateDto My { get; init; }
}

public sealed record FloorDto
{
    public required Guid Id { get; init; }
    public required string Number { get; init; }
    public required SpotDto[] Spots { get; init; }
}

public sealed record SpotDto
{
    public required Guid Id { get; init; }
    public required string Number { get; init; }
    public required string Status { get; init; }
    public required bool IsActive { get; init; }
    public required PropertyDto[] Properties { get; init; }
    public required bool AvailableForMe { get; init; }
    public required bool IsMine { get; init; }
    public OccupantDto? Occupant { get; init; }
}

public sealed record PropertyDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}

public sealed record OccupantDto
{
    public required Guid UserId { get; init; }
    public required string EmployeeId { get; init; }
    public required string FullName { get; init; }
    public required DateTimeOffset OccupiedAt { get; init; }
}

public sealed record MyStateDto
{
    public BookingResponse? Booking { get; init; }
    public SpotRefDto? OccupiedSpot { get; init; }
}

public sealed record SpotRefDto
{
    public required Guid SpotId { get; init; }
    public required string Number { get; init; }
    public required Guid FloorId { get; init; }
    public required string FloorNumber { get; init; }
    public required string Status { get; init; }
}
