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

    protected Address() { }

    public Address(string firstName, string lastName, string email, string streetName, string streetNumber, string neighborhood, string? apartmentNumber, string state, string country, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        StreetName = streetName;
        StreetNumber = streetNumber;
        Neighborhood = neighborhood;
        ApartmentNumber = apartmentNumber;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string email, string streetName, string streetNumber, string neighborhood, string? apartmentNumber, string state, string country, string zipCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        ArgumentException.ThrowIfNullOrEmpty(email);
        ArgumentException.ThrowIfNullOrEmpty(streetName);
        ArgumentException.ThrowIfNullOrEmpty(streetNumber);
        ArgumentException.ThrowIfNullOrEmpty(neighborhood);
        ArgumentException.ThrowIfNullOrEmpty(state);
        ArgumentException.ThrowIfNullOrEmpty(country);
        ArgumentException.ThrowIfNullOrEmpty(zipCode);

        return new Address(
            firstName,
            lastName,
            email,
            streetName,
            streetNumber,
            neighborhood,
            apartmentNumber,
            state,
            country,
            zipCode
        );
    }
}