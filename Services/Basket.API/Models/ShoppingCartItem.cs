namespace Basket.API.Models;

public class ShoppingCartItem
{
    public int Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public int Quantity { get; set; } = default!;

    public decimal Price { get; set; } = default!;
}