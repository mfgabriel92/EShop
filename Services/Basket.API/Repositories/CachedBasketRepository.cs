using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositories;

public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(string username)
    {
        var cached = await cache.GetStringAsync(username);

        if (!string.IsNullOrEmpty(cached))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cached)!;
        }

        var shoppingCart = await repository.GetBasketAsync(username);
        await cache.SetStringAsync(username, JsonSerializer.Serialize(shoppingCart));

        return shoppingCart;
    }

    public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart shoppingCart)
    {
        await repository.StoreBasketAsync(shoppingCart);
        await cache.SetStringAsync(shoppingCart.Username, JsonSerializer.Serialize(shoppingCart));
        return shoppingCart;
    }

    public async Task DeleteBasketAsync(string username)
    {
        await repository.DeleteBasketAsync(username);
        await cache.RemoveAsync(username);
    }
}
