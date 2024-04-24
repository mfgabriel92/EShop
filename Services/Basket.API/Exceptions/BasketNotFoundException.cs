namespace Basket.API.Exceptions;

public class BasketNotFoundException(string username) : NotFoundException($"Basket for username '{username}' not found");