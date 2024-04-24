namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = command.ShoppingCart;
        return new StoreBasketResult(shoppingCart);
    }
}