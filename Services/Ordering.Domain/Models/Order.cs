namespace Ordering.Domain.Models;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = [];

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public CustomerId CustomerId { get; private set; } = default!;

    public string OrderName { get; private set; } = default!;

    public Address ShippingAddress { get; private set; } = default!;

    public Address BillingAddress { get; private set; } = default!;

    public Payment Payment { get; private set; } = default!;

    public OrderStatus OrderStatus { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice
    {
        get => OrderItems.Sum(i => i.Price * i.Quantity);
        private set { }
    }

    public static Order Create(CustomerId customerId, string orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new Order
        {
            Id = OrderId.Of(Guid.NewGuid()),
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            OrderStatus = OrderStatus.Pending,
        };

        // order.AddDomainEvent(new OrderCreatedDomainEvent(order));

        return order;
    }

    public void Update(string orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        OrderStatus = status;

        // AddDomainEvent(new OrderUpdatedDomainEvent(this));
    }

    public void AddItem(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItem(Id, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    public void RemoveItem(ProductId productId)
    {
        var orderItem = _orderItems.Find(x => x.ProductId == productId);

        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}
