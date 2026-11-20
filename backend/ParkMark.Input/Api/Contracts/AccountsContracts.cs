using System.ComponentModel.DataAnnotations;

namespace ParkMark.Input.Api.Contracts;

public sealed record IdentifyRequest
{
    public required string EmployeeId { get; init; }
}

public sealed record RegisterRequest
{
    public required string EmployeeId { get; init; }
    public required string Password { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
}

public sealed record LoginRequest
{
    public required string Login { get; init; }
    public required string Password { get; init; }
}

public sealed record RefreshRequest
{
    public required string RefreshToken { get; init; }
}

public sealed record LogoutRequest
{
    public required string RefreshToken { get; init; }
    public string? PushEndpoint { get; init; }
}

public sealed record ChangePasswordRequest
{
    public required string CurrentPassword { get; init; }
    public required string NewPassword { get; init; }
    public required string RefreshToken { get; init; }
}

public sealed record ChangeLoginRequest
{
    [MinLength(6)]
    public required string NewLogin { get; init; }
    public required string CurrentPassword { get; init; }
}

public sealed record TokenPairResponse
{
    public required string AccessToken { get; init; }
    public required DateTimeOffset AccessTokenExpiresAt { get; init; }
    public required string RefreshToken { get; init; }
}

public sealed record ProfileResponse
{
    public required Guid Id { get; init; }
    public required string EmployeeId { get; init; }
    public required string Login { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
    public required string Role { get; init; }
    public required string[] Tags { get; init; }
}

public sealed record AuthResponse
{
    public required ProfileResponse Profile { get; init; }
    public required TokenPairResponse Tokens { get; init; }
}
