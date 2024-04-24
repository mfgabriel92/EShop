namespace Basket.API.Models;

public class ShoppingCart(string username)
{
    public string Username { get; set; } = username;

    public List<ShoppingCartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
}