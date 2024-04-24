namespace Basket.API.Repositories;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(string username)
    {
        var basket = await session.LoadAsync<ShoppingCart>(username);
        
        if (basket is null)
        {
            throw new BasketNotFoundException(username);
        }

        return basket;
    }

    public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart shoppingCart)
    {
        session.Store(shoppingCart);
        await session.SaveChangesAsync();
        return shoppingCart;
    }

    public async Task DeleteBasketAsync(string username)
    {
        session.Delete(username);
        await session.SaveChangesAsync();
    }
}