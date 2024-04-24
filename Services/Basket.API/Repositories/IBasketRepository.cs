namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string username);

    Task<ShoppingCart> StoreBasketAsync(ShoppingCart shoppingCart);

    Task DeleteBasketAsync(string username);
}