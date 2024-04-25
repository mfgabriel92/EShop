namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = command.ShoppingCart;
        await repository.StoreBasketAsync(shoppingCart);
        return new StoreBasketResult(shoppingCart);
    }
}