namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; } = default!;

    public string LastName { get; } = default!;

    public string Email { get; } = default!;

    public string StreetName { get; } = default!;

    public string StreetNumber { get; } = default!;

    public string Neighborhood { get; } = default!;

    public string? ApartmentNumber { get; } = default!;

    public string State { get; } = default!;

    public string Country { get; } = default!;

    public string ZipCode { get; } = default!;
}