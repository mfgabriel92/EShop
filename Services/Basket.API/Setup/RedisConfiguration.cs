namespace Basket.API.Setup;

public static class RedisConfiguration
{
    public static WebApplicationBuilder AddRedisConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(opts =>
        {
            opts.Configuration = builder.Configuration.GetConnectionString("Redis");
        });

        return builder;
    }
}
