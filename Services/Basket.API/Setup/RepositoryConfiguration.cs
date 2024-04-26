namespace Basket.API.Setup;

public static class RepositoryConfiguration
{
    public static WebApplicationBuilder AddRepositoryConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

        return builder;
    }
}