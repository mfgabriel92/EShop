namespace Ordering.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    public OrderItem(decimal price, int quantity, OrderId orderId, ProductId productId)
    {
        Price = price;
        Quantity = quantity;
        OrderId = orderId;
        ProductId = productId;
    }

    public decimal Price { get; private set; } = default!;

    public int Quantity { get; private set; } = default!;

    public OrderId OrderId { get; private set; } = default!;

    public ProductId ProductId { get; private set; } = default!;
}