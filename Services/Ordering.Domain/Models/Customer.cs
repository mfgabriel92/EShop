namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;

    public string Email { get; private set; } = default!;

    public static Customer Create(string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Customer
        {
            Id = CustomerId.Of(Guid.NewGuid()),
            Name = name,
            Email = email
        };
    }
}
