namespace Ordering.Domain.Models;

public class OrderItem(decimal price, int quantity, Guid orderId, Guid productId) : Entity<Guid>
{
    public decimal Price { get; private set; } = price;

    public int Quantity { get; private set; } = quantity;

    // EF
    public Guid OrderId { get; private set; } = orderId;

    public Guid ProductId { get; private set; } = productId;
}