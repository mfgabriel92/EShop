using Discount.gRPC;

namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = command.ShoppingCart;

        await ApplyDiscount(discountProto, shoppingCart.Items);
        await repository.StoreBasketAsync(shoppingCart);

        return new StoreBasketResult(shoppingCart);
    }

    private static async Task ApplyDiscount(DiscountProtoService.DiscountProtoServiceClient discountProto, List<ShoppingCartItem> items)
    {
        foreach (var item in items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest
            {
                Id = item.Id
            });

            item.Price -= coupon.Amount;
        }
    }
}