namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.ShoppingCart).NotNull().WithMessage("The shopping cart is required");
        RuleFor(x => x.ShoppingCart.Username).NotNull().WithMessage("The username is required");
    }
}